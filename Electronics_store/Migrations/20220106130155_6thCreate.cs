using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Electronics_store.Migrations
{
    public partial class _6thCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataBaseModels");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "OrderProductRelations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "OrderProductRelations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "OrderProductRelations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "OrderProductRelations");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "OrderProductRelations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderProductRelations");

            migrationBuilder.CreateTable(
                name: "DataBaseModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBaseModels", x => x.Id);
                });
        }
    }
}
