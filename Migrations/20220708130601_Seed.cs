using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_2.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Color", "Make", "Model", "NoOfWheels", "PartkingStartAt", "RegNo", "VehicleType" },
                values: new object[,]
                {
                    { 1, 4, "Princes", "Yatch", 0, new DateTime(2022, 7, 8, 15, 6, 1, 216, DateTimeKind.Local).AddTicks(1297), "MDK626", 1 },
                    { 2, 2, "Volvo", "V70", 4, new DateTime(2022, 7, 8, 15, 6, 1, 216, DateTimeKind.Local).AddTicks(1348), "TTT234", 0 },
                    { 3, 0, "Volvo", "240", 4, new DateTime(2022, 7, 8, 15, 6, 1, 216, DateTimeKind.Local).AddTicks(1352), "ABC334", 2 },
                    { 4, 3, "Mercedes", "buss", 4, new DateTime(2022, 7, 8, 15, 6, 1, 216, DateTimeKind.Local).AddTicks(1355), "ZZZ300", 2 },
                    { 5, 1, "Hyunday", "I20", 4, new DateTime(2022, 7, 8, 15, 6, 1, 216, DateTimeKind.Local).AddTicks(1359), "GAG399", 0 },
                    { 6, 2, "Zusuki", "Switch", 4, new DateTime(2022, 7, 8, 15, 6, 1, 216, DateTimeKind.Local).AddTicks(1363), "YYY555", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
