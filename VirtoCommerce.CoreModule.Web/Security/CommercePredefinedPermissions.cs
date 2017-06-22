namespace VirtoCommerce.CoreModule.Web.Security
{
    public static class CommercePredefinedPermissions
    {
        public const string  FulfillmentCreate = "core:fulfillment:create",
            FulfillmentUpdate = "core:fulfillment:update",
            FulfillmentDelete = "core:fulfillment:delete";

        public const string CurrencyCreate = "core:currency:create",
          CurrencyUpdate = "core:currency:update",
          CurrencyDelete = "core:currency:delete";

        public const string PackageTypeCreate = "core:packageType:create",
         PackageTypeUpdate = "core:packageType:update",
         PackageTypeDelete = "core:packageType:delete";

        public const string IndexRebuild = "core:search:index:rebuild";
    }
}
