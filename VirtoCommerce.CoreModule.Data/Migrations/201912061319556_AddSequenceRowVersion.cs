namespace VirtoCommerce.CoreModule.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddSequenceRowVersion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sequence", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }

        public override void Down()
        {
            DropColumn("dbo.Sequence", "RowVersion");
        }
    }
}
