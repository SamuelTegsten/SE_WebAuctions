using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAuctions.Migrations
{
    /// <inheritdoc />
    public partial class BidWhenCreating4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BidDB_AuctionDBs_AuctionId",
                table: "BidDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BidDB",
                table: "BidDB");

            migrationBuilder.RenameTable(
                name: "BidDB",
                newName: "BidDBs");

            migrationBuilder.RenameIndex(
                name: "IX_BidDB_AuctionId",
                table: "BidDBs",
                newName: "IX_BidDBs_AuctionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BidDBs",
                table: "BidDBs",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndDate",
                value: new DateTime(2023, 10, 20, 17, 14, 16, 368, DateTimeKind.Local).AddTicks(2600));

            migrationBuilder.InsertData(
                table: "BidDBs",
                columns: new[] { "Id", "Amount", "AuctionId", "Bidder", "Date" },
                values: new object[,]
                {
                    { -2, 10000000.0, -1, "Esteban", new DateTime(2023, 10, 20, 17, 14, 16, 368, DateTimeKind.Local).AddTicks(3290) },
                    { -1, 500000.0, -1, "Samuel", new DateTime(2023, 10, 20, 17, 14, 16, 368, DateTimeKind.Local).AddTicks(3280) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BidDBs_AuctionDBs_AuctionId",
                table: "BidDBs",
                column: "AuctionId",
                principalTable: "AuctionDBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BidDBs_AuctionDBs_AuctionId",
                table: "BidDBs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BidDBs",
                table: "BidDBs");

            migrationBuilder.DeleteData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.RenameTable(
                name: "BidDBs",
                newName: "BidDB");

            migrationBuilder.RenameIndex(
                name: "IX_BidDBs_AuctionId",
                table: "BidDB",
                newName: "IX_BidDB_AuctionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BidDB",
                table: "BidDB",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndDate",
                value: new DateTime(2023, 10, 20, 17, 1, 55, 863, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.AddForeignKey(
                name: "FK_BidDB_AuctionDBs_AuctionId",
                table: "BidDB",
                column: "AuctionId",
                principalTable: "AuctionDBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
