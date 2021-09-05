using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YoutubeTree.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    youtubeid = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "varchar(800)", maxLength: 800, nullable: false),
                    publishedat = table.Column<DateTime>(type: "timestamp", nullable: true),
                    defaultthumbnail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    mediumthumbnail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    highthumbnail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscriptions", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscriptions");
        }
    }
}
