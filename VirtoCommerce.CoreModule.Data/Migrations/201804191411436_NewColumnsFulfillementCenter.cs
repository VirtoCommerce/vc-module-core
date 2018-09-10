namespace VirtoCommerce.CoreModule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnsFulfillementCenter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FulfillmentCenter", "RegionId", c => c.String(maxLength: 128));
            AddColumn("dbo.FulfillmentCenter", "RegionName", c => c.String(maxLength: 128));
            AddColumn("dbo.FulfillmentCenter", "Email", c => c.String(maxLength: 256));
            AddColumn("dbo.FulfillmentCenter", "Organization", c => c.String(maxLength: 128));
            AddColumn("dbo.FulfillmentCenter", "GeoLocation", c => c.String(maxLength: 64));
            AlterColumn("dbo.FulfillmentCenter", "DaytimePhoneNumber", c => c.String(maxLength: 64));
            AlterColumn("dbo.FulfillmentCenter", "Line1", c => c.String(maxLength: 1024));
            AlterColumn("dbo.FulfillmentCenter", "Line2", c => c.String(maxLength: 1024));
            AlterColumn("dbo.FulfillmentCenter", "City", c => c.String(maxLength: 128));
            AlterColumn("dbo.FulfillmentCenter", "CountryCode", c => c.String(maxLength: 64));
            AlterColumn("dbo.FulfillmentCenter", "CountryName", c => c.String(maxLength: 128));
            AlterColumn("dbo.FulfillmentCenter", "PostalCode", c => c.String(maxLength: 32));
            DropColumn("dbo.FulfillmentCenter", "MaxReleasesPerPickBatch");
            DropColumn("dbo.FulfillmentCenter", "PickDelay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FulfillmentCenter", "PickDelay", c => c.Int(nullable: false));
            AddColumn("dbo.FulfillmentCenter", "MaxReleasesPerPickBatch", c => c.Int(nullable: false));
            AlterColumn("dbo.FulfillmentCenter", "PostalCode", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.FulfillmentCenter", "CountryName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.FulfillmentCenter", "CountryCode", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.FulfillmentCenter", "City", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.FulfillmentCenter", "Line2", c => c.String(maxLength: 128));
            AlterColumn("dbo.FulfillmentCenter", "Line1", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.FulfillmentCenter", "DaytimePhoneNumber", c => c.String(nullable: false, maxLength: 32));
            DropColumn("dbo.FulfillmentCenter", "GeoLocation");
            DropColumn("dbo.FulfillmentCenter", "Organization");
            DropColumn("dbo.FulfillmentCenter", "Email");
            DropColumn("dbo.FulfillmentCenter", "RegionName");
            DropColumn("dbo.FulfillmentCenter", "RegionId");
        }
    }
}
