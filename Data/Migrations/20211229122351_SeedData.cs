using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuyOrSell.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                   table: "ApplicationUser",
                   columns: new[] { "Id", "FirstName", "Lastname" },
                   values: new object[] { 1, "Nemanja", "NASMETAJ" });

            migrationBuilder.InsertData(
                table: "Ads",
                columns: new[] { "Id", "ApplicationUserID", "Cattegory", "Date", "Description", "Name", "Price", "Town", "Url" },
                values: new object[] { 1, "1", "NASMETAJ", new DateTime(2021, 12, 29, 12, 23, 50, 786, DateTimeKind.Utc).AddTicks(7264), "NOVO NOVO NOVO", "OGLAS1", 99.989999999999995, "Novi Sad", "https://www.ikea.com/rs/sr/p/stefan-stolica-smede-crna-00211088/" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
