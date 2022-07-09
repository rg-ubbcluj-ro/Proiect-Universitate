using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "UsersItems",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[] { 1000, new DateTime(2022, 7, 7, 23, 49, 59, 895, DateTimeKind.Local).AddTicks(869), "andrei.carafa@ubbcluj.ro", "Andrei", "Carafa", "AQAAAAEAACcQAAAAEG9i1H2gUNoYZuiGA8ip/md5YsLbqza9jupnzq0sdeVikHtnytkSt3hBmCO2mV3/6A==", "student" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersItems",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.InsertData(
                table: "UsersItems",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[] { 2, new DateTime(2022, 7, 7, 23, 47, 14, 116, DateTimeKind.Local).AddTicks(9665), "andrei.carafa@ubbcluj.ro", "Andrei", "Carafa", "AQAAAAEAACcQAAAAEBZkJZQ0fBG/QvFSUqpsYswmNyrkamaKHHureIy2VuInROxbIpL/4NvXlKc4Q/V5ug==", "student" });
        }
    }
}
