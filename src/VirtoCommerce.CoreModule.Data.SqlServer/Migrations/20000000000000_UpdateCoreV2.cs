using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtoCommerce.CoreModule.Data.SqlServer.Migrations
{
    public partial class UpdateCoreV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '__MigrationHistory'))
                IF (EXISTS (SELECT * FROM __MigrationHistory WHERE ContextKey = 'VirtoCommerce.CoreModule.Data.Migrations.Configuration'))
                    BEGIN
	                    INSERT INTO [__EFMigrationsHistory] ([MigrationId],[ProductVersion]) VALUES ('20190510073611_InitialCore', '2.2.3-servicing-35854')
                        INSERT INTO [__EFMigrationsHistory] ([MigrationId],[ProductVersion]) VALUES ('20191218135758_AddSequenceRowVersion', '2.2.3-servicing-35854')
                    END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
