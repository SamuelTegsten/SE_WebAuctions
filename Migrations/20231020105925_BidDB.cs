using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAuctions.Migrations
{
    /// <inheritdoc />
    public partial class BidDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemDBs",
                keyColumn: "Name",
                keyValue: "Garbage");

            migrationBuilder.DropColumn(
                name: "Bid",
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
                newName: "AuctionName");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "AuctionDBs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BidDBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BidPlacedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidDBs_AuctionDBs_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "AuctionName", "Date", "ExpirationDate", "ItemName" },
                values: new object[] { "user", new DateTime(2023, 10, 20, 12, 59, 25, 127, DateTimeKind.Local).AddTicks(1819), new DateTime(2023, 10, 23, 12, 59, 25, 127, DateTimeKind.Local).AddTicks(1778), "testItem" });

            migrationBuilder.CreateIndex(
                name: "IX_BidDBs_AuctionId",
                table: "BidDBs",
                column: "AuctionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidDBs");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "AuctionDBs");

            migrationBuilder.RenameColumn(
                name: "AuctionName",
                table: "AuctionDBs",
                newName: "Username");

            migrationBuilder.AddColumn<double>(
                name: "Bid",
                table: "AuctionDBs",
                type: "float",
                maxLength: 128,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "AuctionDBs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AuctionDBs",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Bid", "Date", "Duration", "ItemName", "Status", "Username" },
                values: new object[] { 0.0, new DateTime(2023, 10, 15, 11, 32, 25, 701, DateTimeKind.Local).AddTicks(6801), 240, "start", 1, "start" });

            migrationBuilder.InsertData(
                table: "ItemDBs",
                columns: new[] { "Name", "Description", "Picture" },
                values: new object[] { "Garbage", "garbage", "images/garbage.png" });
        }
    }
}
