using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class Controllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    UniversityYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfStudy = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsItems_UsersItems_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeachersItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DidacticRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachersItems_UsersItems_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoursesItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTeacher = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesItems_TeachersItems_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "TeachersItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GradesItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCourse = table.Column<int>(type: "int", nullable: false),
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    IdTeacher = table.Column<int>(type: "int", nullable: false),
                    IdSession = table.Column<int>(type: "int", nullable: false),
                    GradeValue = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    SessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradesItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradesItems_CoursesItems_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CoursesItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GradesItems_SessionItems_SessionId",
                        column: x => x.SessionId,
                        principalTable: "SessionItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GradesItems_StudentsItems_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentsItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GradesItems_TeachersItems_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "TeachersItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesItems_TeacherId",
                table: "CoursesItems",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_GradesItems_CourseId",
                table: "GradesItems",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_GradesItems_SessionId",
                table: "GradesItems",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_GradesItems_StudentId",
                table: "GradesItems",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GradesItems_TeacherId",
                table: "GradesItems",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsItems_UserId",
                table: "StudentsItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersItems_UserId",
                table: "TeachersItems",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradesItems");

            migrationBuilder.DropTable(
                name: "CoursesItems");

            migrationBuilder.DropTable(
                name: "SessionItems");

            migrationBuilder.DropTable(
                name: "StudentsItems");

            migrationBuilder.DropTable(
                name: "TeachersItems");

            migrationBuilder.DropTable(
                name: "UsersItems");
        }
    }
}
