using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApp.Services.EmployeeAPI.Migrations
{
    public partial class addTestEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "BaseSalary", "Name" },
                values: new object[] { 1, 15000.0, "Worker" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "BaseSalary", "Name" },
                values: new object[] { 2, 50000.0, "Director" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "FIO", "PersonnelNumber", "PositionId", "RegularOrExternal" },
                values: new object[] { 1, new DateTime(1990, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.A.Ivanov", 11111, 2, false });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "FIO", "PersonnelNumber", "PositionId", "RegularOrExternal" },
                values: new object[] { 2, new DateTime(1985, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.G.Petrov", null, 1, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionId",
                keyValue: 2);
        }
    }
}
