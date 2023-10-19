using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAuctions.Migrations
{
    /// <inheritdoc />
    public partial class BidsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bid",
                table: "AuctionDBs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "AuctionDBs");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "AuctionDBs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AuctionDBs");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "AuctionDBs",
                newName: "EndDate");

            migrationBuilder.AddColumn<string>(
                name: "Auctioneer",
                table: "AuctionDBs",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "OpeningPrice",
                table: "AuctionDBs",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "BidDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bidder = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AuctionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidDB_AuctionDBs_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Auctioneer", "EndDate", "OpeningPrice" },
                values: new object[] { "user", new DateTime(2023, 10, 20, 0, 3, 59, 941, DateTimeKind.Local).AddTicks(880), 5000.5 });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDBs_ItemName",
                table: "AuctionDBs",
                column: "ItemName");

            migrationBuilder.CreateIndex(
                name: "IX_BidDB_AuctionId",
                table: "BidDB",
                column: "AuctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionDBs_ItemDBs_ItemName",
                table: "AuctionDBs",
                column: "ItemName",
                principalTable: "ItemDBs",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionDBs_ItemDBs_ItemName",
                table: "AuctionDBs");

            migrationBuilder.DropTable(
                name: "BidDB");

            migrationBuilder.DropIndex(
                name: "IX_AuctionDBs_ItemName",
                table: "AuctionDBs");

            migrationBuilder.DropColumn(
                name: "Auctioneer",
                table: "AuctionDBs");

            migrationBuilder.DropColumn(
                name: "OpeningPrice",
                table: "AuctionDBs");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "AuctionDBs",
                newName: "Username");

            migrationBuilder.AddColumn<double>(
                name: "Bid",
                table: "AuctionDBs",
                type: "REAL",
                maxLength: 128,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "AuctionDBs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "AuctionDBs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AuctionDBs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Bid", "Date", "Duration", "Status", "Username" },
                values: new object[] { 50.0, new DateTime(2023, 10, 19, 19, 25, 56, 744, DateTimeKind.Local).AddTicks(6350), 3, 0, "user" });
        }
    }
}
