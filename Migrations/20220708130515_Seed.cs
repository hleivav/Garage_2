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
                    { 1, 4, "Volvo", "V70", 4, new DateTime(2022, 7, 8, 15, 5, 15, 42, DateTimeKind.Local).AddTicks(3878), "MDK626", 0 },
                    { 2, 2, "tesla", "D3", 4, new DateTime(2022, 7, 8, 15, 5, 15, 42, DateTimeKind.Local).AddTicks(3906), "TTT234", 0 },
                    { 3, 3, "mercedes", "C-Klass", 4, new DateTime(2022, 7, 8, 15, 5, 15, 42, DateTimeKind.Local).AddTicks(3909), "ABC123", 0 },
                    { 4, 1, "Volvo", "Volvobuss", 8, new DateTime(2022, 7, 8, 15, 5, 15, 42, DateTimeKind.Local).AddTicks(3911), "DUM666", 2 },
                    { 5, 3, "Princess", "Yatch", 0, new DateTime(2022, 7, 8, 15, 5, 15, 42, DateTimeKind.Local).AddTicks(3913), "MUU775", 1 },
                    { 6, 0, "Volvo", "V90", 4, new DateTime(2022, 7, 8, 15, 5, 15, 42, DateTimeKind.Local).AddTicks(3915), "YUU223", 0 }
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
