using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtoCommerce.CoreModule.Data.SqlServer.Migrations
{
    public partial class RoundingPolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MidpointRounding",
                table: "Currency",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoundingType",
                table: "Currency",
                maxLength: 16,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MidpointRounding",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "RoundingType",
                table: "Currency");
        }
    }
}
