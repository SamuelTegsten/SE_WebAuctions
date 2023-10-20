using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAuctions.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionDBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Bid = table.Column<double>(type: "float", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDBs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemDBs",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDBs", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "AuctionDBs",
                columns: new[] { "Id", "Bid", "Date", "Duration", "ItemName", "Status", "Username" },
                values: new object[] { -1, 0.0, new DateTime(2023, 10, 15, 11, 32, 25, 701, DateTimeKind.Local).AddTicks(6801), 240, "start", 1, "start" });

            migrationBuilder.InsertData(
                table: "ItemDBs",
                columns: new[] { "Name", "Description", "Picture" },
                values: new object[] { "Garbage", "garbage", "images/garbage.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionDBs");

            migrationBuilder.DropTable(
                name: "ItemDBs");
        }
    }
}
