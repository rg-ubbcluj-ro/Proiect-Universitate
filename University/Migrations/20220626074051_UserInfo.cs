using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class UserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsItems_UsersItems_UserId",
                table: "StudentsItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersItems_UsersItems_UserId",
                table: "TeachersItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TeachersItems",
                newName: "UserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_TeachersItems_UserId",
                table: "TeachersItems",
                newName: "IX_TeachersItems_UserInfoId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "StudentsItems",
                newName: "UserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsItems_UserId",
                table: "StudentsItems",
                newName: "IX_StudentsItems_UserInfoId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UsersItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UsersItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsItems_UsersItems_UserInfoId",
                table: "StudentsItems",
                column: "UserInfoId",
                principalTable: "UsersItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersItems_UsersItems_UserInfoId",
                table: "TeachersItems",
                column: "UserInfoId",
                principalTable: "UsersItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsItems_UsersItems_UserInfoId",
                table: "StudentsItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersItems_UsersItems_UserInfoId",
                table: "TeachersItems");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "TeachersItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TeachersItems_UserInfoId",
                table: "TeachersItems",
                newName: "IX_TeachersItems_UserId");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "StudentsItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsItems_UserInfoId",
                table: "StudentsItems",
                newName: "IX_StudentsItems_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UsersItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UsersItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsItems_UsersItems_UserId",
                table: "StudentsItems",
                column: "UserId",
                principalTable: "UsersItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersItems_UsersItems_UserId",
                table: "TeachersItems",
                column: "UserId",
                principalTable: "UsersItems",
                principalColumn: "Id");
        }
    }
}
