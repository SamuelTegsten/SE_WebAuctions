using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAuctions.Migrations
{
    /// <inheritdoc />
    public partial class BidWhenCreating2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndDate",
                value: new DateTime(2023, 10, 20, 16, 53, 56, 666, DateTimeKind.Local).AddTicks(9140));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndDate",
                value: new DateTime(2023, 10, 20, 16, 52, 23, 9, DateTimeKind.Local).AddTicks(7720));
        }
    }
}
