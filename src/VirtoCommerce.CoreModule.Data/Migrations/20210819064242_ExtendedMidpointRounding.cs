using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtoCommerce.CoreModule.Data.Migrations
{
    public partial class ExtendedMidpointRounding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MidpointRounding",
                table: "Currency",
                maxLength: 18,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MidpointRounding",
                table: "Currency",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 18,
                oldNullable: true);
        }
    }
}
