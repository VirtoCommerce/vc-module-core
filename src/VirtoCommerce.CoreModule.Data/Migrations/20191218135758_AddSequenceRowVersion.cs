using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtoCommerce.CoreModule.Data.Migrations
{
    public partial class AddSequenceRowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Sequence",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Sequence");
        }
    }
}
