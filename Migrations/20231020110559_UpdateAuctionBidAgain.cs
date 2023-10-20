using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAuctions.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuctionBidAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Date", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 10, 20, 13, 5, 59, 329, DateTimeKind.Local).AddTicks(6422), new DateTime(2023, 10, 23, 13, 5, 59, 329, DateTimeKind.Local).AddTicks(6383) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Date", "ExpirationDate" },
                values: new object[] { new DateTime(2023, 10, 20, 13, 1, 51, 229, DateTimeKind.Local).AddTicks(3901), new DateTime(2023, 10, 23, 13, 1, 51, 229, DateTimeKind.Local).AddTicks(3861) });
        }
    }
}
