using System;
using System.Linq;
using System.Web.Http;
using Hangfire;
using Microsoft.Practices.Unity;
using VirtoCommerce.CoreModule.Data.Indexing;
using VirtoCommerce.CoreModule.Data.Observers;
using VirtoCommerce.CoreModule.Data.Payment;
using VirtoCommerce.CoreModule.Data.Repositories;
using VirtoCommerce.CoreModule.Data.Search.SearchPhraseParsing;
using VirtoCommerce.CoreModule.Data.Services;
using VirtoCommerce.CoreModule.Data.Shipping;
using VirtoCommerce.CoreModule.Data.Tax;
using VirtoCommerce.CoreModule.Web.BackgroundJobs;
using VirtoCommerce.CoreModule.Web.ExportImport;
using VirtoCommerce.CoreModule.Web.JsonConverters;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Commerce.Services;
using VirtoCommerce.Domain.Customer.Events;
using VirtoCommerce.Domain.Payment.Services;
using VirtoCommerce.Domain.Search;
using VirtoCommerce.Domain.Shipping.Services;
using VirtoCommerce.Domain.Tax.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.ExportImport;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Core.Settings;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace VirtoCommerce.CoreModule.Web
{
    public class Module : ModuleBase, ISupportExportImportModule
    {
        private static readonly string _connectionString = ConnectionStringHelper.GetConnectionString("VirtoCommerce");
        private readonly IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            _container = container;
        }

        #region IModule Members

        public override void SetupDatabase()
        {
            using (var db = new CommerceRepositoryImpl(_connectionString, _container.Resolve<AuditableInterceptor>()))
            {
                var initializer = new SetupDatabaseInitializer<CommerceRepositoryImpl, Data.Migrations.Configuration>();
                initializer.InitializeDatabase(db);
            }
        }

        public override void Initialize()
        {
            //#region Payment gateways manager

            //_container.RegisterType<IPaymentGatewayManager, InMemoryPaymentGatewayManagerImpl>(new ContainerControlledLifetimeManager());

            //#endregion

            #region Commerce

            _container.RegisterType<ICommerceRepository>(new InjectionFactory(c => new CommerceRepositoryImpl(_connectionString, new EntityPrimaryKeyGeneratorInterceptor(), _container.Resolve<AuditableInterceptor>())));
            _container.RegisterType<ICommerceService, CommerceServiceImpl>();

            #endregion

            #region Tax service
            var taxService = new TaxServiceImpl();
            _container.RegisterInstance<ITaxService>(taxService);
            #endregion
            #region Shipping service
            var shippingService = new ShippingMethodsServiceImpl();
            _container.RegisterInstance<IShippingMethodsService>(shippingService);
            #endregion

            #region Payment service
            var paymentService = new PaymentMethodsServiceImpl();
            _container.RegisterInstance<IPaymentMethodsService>(paymentService);
            #endregion

            //Registration welcome email notification.
            _container.RegisterType<IObserver<MemberChangingEvent>, RegistrationEmailObserver>("RegistrationEmailObserver");

            #region Search

            _container.RegisterType<ISearchPhraseParser, SearchPhraseParser>();

            _container.RegisterType<IIndexingWorker, HangfireIndexingWorker>();
            _container.RegisterType<IIndexingManager, IndexingManager>();

            var searchConnectionString = ConnectionStringHelper.GetConnectionString("SearchConnectionString");

            if (string.IsNullOrEmpty(searchConnectionString))
            {
                var settingsManager = _container.Resolve<ISettingsManager>();
                searchConnectionString = settingsManager.GetValue("VirtoCommerce.Search.SearchConnectionString", string.Empty);
            }

            if (!string.IsNullOrEmpty(searchConnectionString))
            {
                var searchConnection = new SearchConnection(searchConnectionString);
                _container.RegisterInstance<ISearchConnection>(searchConnection);
            }

            #endregion
        }

        public override void PostInitialize()
        {
            var settingsManager = _container.Resolve<ISettingsManager>();
            var commerceService = _container.Resolve<ICommerceService>();
            var shippingService = _container.Resolve<IShippingMethodsService>();
            var taxService = _container.Resolve<ITaxService>();
            var paymentService = _container.Resolve<IPaymentMethodsService>();
            var moduleSettings = settingsManager.GetModuleSettings("VirtoCommerce.Core");

            taxService.RegisterTaxProvider(() => new FixedTaxRateProvider(moduleSettings.First(x => x.Name == "VirtoCommerce.Core.FixedTaxRateProvider.Rate"))
            {
                Name = "fixed tax rate",
                Description = "Fixed percent tax rate",
                LogoUrl = "https://raw.githubusercontent.com/VirtoCommerce/vc-module-core/master/VirtoCommerce.CoreModule.Web/Content/logoVC.png"
            });

            shippingService.RegisterShippingMethod(() => new FixedRateShippingMethod(moduleSettings.Where(x => x.Name.StartsWith("VirtoCommerce.Core.FixedRateShippingMethod")).ToArray())
            {
                Name = "fixed shipping rate",
                Description = "Fixed rate shipping method",
                LogoUrl = "https://raw.githubusercontent.com/VirtoCommerce/vc-module-core/master/VirtoCommerce.CoreModule.Web/Content/logoVC.png"

            });

            paymentService.RegisterPaymentMethod(() => new DefaultManualPaymentMethod
            {
                IsActive = true,
                Name = "Manual test payment method",
                Description = "Manual test, don't use on production",
                LogoUrl = "https://raw.githubusercontent.com/VirtoCommerce/vc-module-core/master/VirtoCommerce.CoreModule.Web/Content/logoVC.png",
            });

            var currencies = commerceService.GetAllCurrencies();
            if (!currencies.Any())
            {
                var defaultCurrency = new Currency
                {
                    Code = "USD",
                    IsPrimary = true,
                    ExchangeRate = 1,
                    Symbol = "$",
                    Name = "US dollar"
                };
                commerceService.UpsertCurrencies(new[] { defaultCurrency });
            }

            //Next lines allow to use polymorph types in API controller methods
            var httpConfiguration = _container.Resolve<HttpConfiguration>();
            httpConfiguration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new PolymorphicJsonConverter());

            #region Search

            // Enable or disable periodic search index builders
            var scheduleJobs = settingsManager.GetValue("VirtoCommerce.Search.IndexingJobs.Enable", true);
            if (scheduleJobs)
            {
                var cronExpression = settingsManager.GetValue("VirtoCommerce.Search.IndexingJobs.CronExpression", "0/5 * * * *");
                RecurringJob.AddOrUpdate<IndexingJobs>(j => j.IndexChangesJob(null), cronExpression);
            }

            #endregion
        }

        #endregion

        #region ISupportExportImportModule Members

        public void DoExport(System.IO.Stream outStream, PlatformExportManifest manifest, Action<ExportImportProgressInfo> progressCallback)
        {
            var job = _container.Resolve<CoreExportImport>();
            job.DoExport(outStream, progressCallback);
        }

        public void DoImport(System.IO.Stream inputStream, PlatformExportManifest manifest, Action<ExportImportProgressInfo> progressCallback)
        {
            var job = _container.Resolve<CoreExportImport>();
            job.DoImport(inputStream, progressCallback);
        }

        public string ExportDescription
        {
            get
            {
                var settingManager = _container.Resolve<ISettingsManager>();
                return settingManager.GetValue("VirtoCommerce.Core.ExportImport.Description", string.Empty);
            }
        }

        #endregion
    }
}
