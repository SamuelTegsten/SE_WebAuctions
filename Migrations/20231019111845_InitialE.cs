using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAuctions.Migrations
{
    /// <inheritdoc />
    public partial class InitialE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionDBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Bid = table.Column<double>(type: "REAL", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDBs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemDBs",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Picture = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDBs", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "UserDBs",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Permission = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDBs", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "AuctionDBs",
                columns: new[] { "Id", "Bid", "Date", "Duration", "ItemName", "Status", "Username" },
                values: new object[] { -1, 50.0, new DateTime(2023, 10, 19, 13, 18, 45, 461, DateTimeKind.Local).AddTicks(6490), 3, "Large Tent", 0, "user" });

            migrationBuilder.InsertData(
                table: "ItemDBs",
                columns: new[] { "Name", "Description", "Picture" },
                values: new object[] { "Large Tent", "A Large Tent", "images/tent1.png" });

            migrationBuilder.InsertData(
                table: "UserDBs",
                columns: new[] { "UserId", "Password", "Permission", "Username" },
                values: new object[] { -1, "password", 0, "user" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionDBs");

            migrationBuilder.DropTable(
                name: "ItemDBs");

            migrationBuilder.DropTable(
                name: "UserDBs");
        }
    }
}
