using System;
using System.IO;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Commerce.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.ExportImport;

namespace VirtoCommerce.CoreModule.Web.ExportImport
{
    public sealed class BackupObject
	{
        public Currency[] Currencies { get; set; }
        public PackageType[] PackageTypes { get; set; }
	}

	public sealed class CoreExportImport
	{
		private readonly ICommerceService _commerceService;

		public CoreExportImport(ICommerceService commerceService)
		{
			_commerceService = commerceService;
		}

		public void DoExport(Stream backupStream, Action<ExportImportProgressInfo> progressCallback)
		{
			var backupObject = GetBackupObject(progressCallback);
			backupObject.SerializeJson(backupStream);
		}

		public void DoImport(Stream backupStream, Action<ExportImportProgressInfo> progressCallback)
		{
			var backupObject = backupStream.DeserializeJson<BackupObject>();
         
            progressCallback(new ExportImportProgressInfo("importing currencies"));
            if (backupObject.Currencies != null)
            {
                _commerceService.UpsertCurrencies(backupObject.Currencies);
            }
            progressCallback(new ExportImportProgressInfo("importing package types"));
            if (backupObject.PackageTypes != null)
            {
                _commerceService.UpsertPackageTypes(backupObject.PackageTypes);
            }

        }

		private BackupObject GetBackupObject(Action<ExportImportProgressInfo> progressCallback)
		{
            progressCallback(new ExportImportProgressInfo("currencies loading"));
            var currencies = _commerceService.GetAllCurrencies().ToArray();
            progressCallback(new ExportImportProgressInfo(string.Format("currencies loaded: {0}", currencies.Count())));

            progressCallback(new ExportImportProgressInfo("package types loading"));
            var packageTypes = _commerceService.GetAllPackageTypes().ToArray();
            progressCallback(new ExportImportProgressInfo(string.Format("package types  loaded: {0}", packageTypes.Count())));

            return new BackupObject()
            {           
                Currencies = currencies,
                PackageTypes = packageTypes
			};
		}
	}
}
