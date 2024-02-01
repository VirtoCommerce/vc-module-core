using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtoCommerce.CoreModule.Data.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRowVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RowVersion",
                table: "Sequence",
                newName: "xmin");

            migrationBuilder.AlterColumn<uint>(
                name: "xmin",
                table: "Sequence",
                type: "xid",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldRowVersion: true,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "xmin",
                table: "Sequence",
                newName: "RowVersion");

            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "Sequence",
                type: "bytea",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(uint),
                oldType: "xid",
                oldRowVersion: true,
                oldNullable: true);
        }
    }
}
