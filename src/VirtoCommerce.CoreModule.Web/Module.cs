using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using VirtoCommerce.CoreModule.Core;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.CoreModule.Core.Conditions;
using VirtoCommerce.CoreModule.Core.Currency;
using VirtoCommerce.CoreModule.Core.Package;
using VirtoCommerce.CoreModule.Core.Seo;
using VirtoCommerce.CoreModule.Data.Currency;
using VirtoCommerce.CoreModule.Data.MySql;
using VirtoCommerce.CoreModule.Data.Package;
using VirtoCommerce.CoreModule.Data.PostgreSql;
using VirtoCommerce.CoreModule.Data.Repositories;
using VirtoCommerce.CoreModule.Data.Seo;
using VirtoCommerce.CoreModule.Data.Services;
using VirtoCommerce.CoreModule.Data.SqlServer;
using VirtoCommerce.CoreModule.Web.ExportImport;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.ExportImport;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Platform.Core.Settings;
using VirtoCommerce.Platform.Data.Extensions;

namespace VirtoCommerce.CoreModule.Web
{
    public class Module : IModule, IExportSupport, IImportSupport, IHasConfiguration
    {
        private IApplicationBuilder _appBuilder;

        public ManifestModuleInfo ModuleInfo { get; set; }
        public IConfiguration Configuration { get; set; }

        public void Initialize(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<CoreDbContext>((provider, options) =>
            {
                var databaseProvider = Configuration.GetValue("DatabaseProvider", "SqlServer");
                var connectionString = Configuration.GetConnectionString(ModuleInfo.Id) ?? Configuration.GetConnectionString("VirtoCommerce");

                switch (databaseProvider)
                {
                    case "MySql":
                        options.UseMySqlDatabase(connectionString);
                        break;
                    case "PostgreSql":
                        options.UsePostgreSqlDatabase(connectionString);
                        break;
                    default:
                        options.UseSqlServerDatabase(connectionString);
                        break;
                }
            });

            serviceCollection.AddTransient<ICoreRepository, CoreRepositoryImpl>();
            serviceCollection.AddTransient<Func<ICoreRepository>>(provider => () => provider.CreateScope().ServiceProvider.GetRequiredService<ICoreRepository>());
            serviceCollection.AddTransient<ICurrencyService, CurrencyService>();
            serviceCollection.AddTransient<IPackageTypesService, PackageTypesService>();
            //Can be overridden
            serviceCollection.AddTransient<ISeoDuplicatesDetector, NullSeoDuplicateDetector>();
            serviceCollection.AddTransient<CoreExportImport>();
            serviceCollection.AddTransient<IUniqueNumberGenerator, SequenceUniqueNumberGeneratorService>();

            serviceCollection.AddTransient<CompositeSeoBySlugResolver>();

            // Money rounding
            serviceCollection.AddTransient<IMoneyRoundingPolicy, DefaultMoneyRoundingPolicy>();

            serviceCollection.AddOptions<SequenceNumberGeneratorOptions>().Bind(Configuration.GetSection("VirtoCommerce:SequenceNumberGenerator")).ValidateDataAnnotations();
        }

        public void PostInitialize(IApplicationBuilder appBuilder)
        {
            _appBuilder = appBuilder;
            var settingsRegistrar = appBuilder.ApplicationServices.GetRequiredService<ISettingsRegistrar>();
            settingsRegistrar.RegisterSettings(ModuleConstants.Settings.AllSettings, ModuleInfo.Id);

            var permissionsRegistrar = appBuilder.ApplicationServices.GetRequiredService<IPermissionsRegistrar>();
            permissionsRegistrar.RegisterPermissions(ModuleInfo.Id, "Core", ModuleConstants.Security.Permissions.AllPermissions);

            var mvcJsonOptions = appBuilder.ApplicationServices.GetService<IOptions<MvcNewtonsoftJsonOptions>>();
            mvcJsonOptions.Value.SerializerSettings.Converters.Add(new ConditionJsonConverter());

            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var databaseProvider = Configuration.GetValue("DatabaseProvider", "SqlServer");
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<CoreDbContext>();
                if (databaseProvider == "SqlServer")
                {
                    dbContext.Database.MigrateIfNotApplied(MigrationName.GetUpdateV2MigrationName(ModuleInfo.Id));
                }
                dbContext.Database.Migrate();
            }
        }

        public void Uninstall()
        {
            // Method intentionally left empty.
        }

        public Task ExportAsync(Stream outStream, ExportImportOptions options, Action<ExportImportProgressInfo> progressCallback, ICancellationToken cancellationToken)
        {
            return _appBuilder.ApplicationServices.GetRequiredService<CoreExportImport>().ExportAsync(outStream, options, progressCallback, cancellationToken);
        }

        public Task ImportAsync(Stream inputStream, ExportImportOptions options, Action<ExportImportProgressInfo> progressCallback,
            ICancellationToken cancellationToken)
        {
            return _appBuilder.ApplicationServices.GetRequiredService<CoreExportImport>().ImportAsync(inputStream, options, progressCallback, cancellationToken);
        }
    }
}
