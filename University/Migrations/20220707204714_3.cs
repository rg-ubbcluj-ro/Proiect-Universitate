﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "UsersItems",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[] { 2, new DateTime(2022, 7, 7, 23, 47, 14, 116, DateTimeKind.Local).AddTicks(9665), "andrei.carafa@ubbcluj.ro", "Andrei", "Carafa", "AQAAAAEAACcQAAAAEBZkJZQ0fBG/QvFSUqpsYswmNyrkamaKHHureIy2VuInROxbIpL/4NvXlKc4Q/V5ug==", "student" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "UsersItems",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[] { 1, new DateTime(2022, 7, 7, 23, 45, 46, 758, DateTimeKind.Local).AddTicks(228), "andrei.carafa@ubbcluj.ro", "Andrei", "Carafa", "AQAAAAEAACcQAAAAEHbM4k3oe7QsTUO0phwcoT9stBBTHCZ1zLKYCuEHndce6kLqhUWKLyawiT0GGXDVFw==", "student" });
        }
    }
}
