using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201_Tutor_Web_API.Migrations
{
    public partial class CreateDatabaseExe_17022024_15h39 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avatar = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avatar = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Coursera",
                columns: table => new
                {
                    CourseraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coursera", x => x.CourseraId);
                    table.ForeignKey(
                        name: "FK_Coursera_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseraDetail",
                columns: table => new
                {
                    CourseraDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseraId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseraDetail", x => x.CourseraDetailId);
                    table.ForeignKey(
                        name: "FK_CourseraDetail_Coursera_CourseraId",
                        column: x => x.CourseraId,
                        principalTable: "Coursera",
                        principalColumn: "CourseraId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OnCoursera",
                columns: table => new
                {
                    OnCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    CourseraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnCoursera", x => x.OnCourseId);
                    table.ForeignKey(
                        name: "FK_OnCoursera_Coursera_CourseraId",
                        column: x => x.CourseraId,
                        principalTable: "Coursera",
                        principalColumn: "CourseraId");
                    table.ForeignKey(
                        name: "FK_OnCoursera_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mooc",
                columns: table => new
                {
                    MoocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseraDetailId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MinScore = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mooc", x => x.MoocId);
                    table.ForeignKey(
                        name: "FK_Mooc_CourseraDetail_CourseraDetailId",
                        column: x => x.CourseraDetailId,
                        principalTable: "CourseraDetail",
                        principalColumn: "CourseraDetailId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OnCourseDetail",
                columns: table => new
                {
                    OnCourseDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourseraDetailId = table.Column<int>(type: "int", nullable: true),
                    OnCourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnCourseDetail", x => x.OnCourseDetailId);
                    table.ForeignKey(
                        name: "FK_OnCourseDetail_CourseraDetail_CourseraDetailId",
                        column: x => x.CourseraDetailId,
                        principalTable: "CourseraDetail",
                        principalColumn: "CourseraDetailId");
                    table.ForeignKey(
                        name: "FK_OnCourseDetail_OnCoursera_OnCourseId",
                        column: x => x.OnCourseId,
                        principalTable: "OnCoursera",
                        principalColumn: "OnCourseId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MoocDetail",
                columns: table => new
                {
                    MoocDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MoocId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Score = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoocDetail", x => x.MoocDetailId);
                    table.ForeignKey(
                        name: "FK_MoocDetail_Mooc_MoocId",
                        column: x => x.MoocId,
                        principalTable: "Mooc",
                        principalColumn: "MoocId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OnMooc",
                columns: table => new
                {
                    OnMoocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TotalScore = table.Column<int>(type: "int", nullable: true),
                    DateSuccess = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MoocId = table.Column<int>(type: "int", nullable: true),
                    OnCourseDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnMooc", x => x.OnMoocId);
                    table.ForeignKey(
                        name: "FK_OnMooc_Mooc_MoocId",
                        column: x => x.MoocId,
                        principalTable: "Mooc",
                        principalColumn: "MoocId");
                    table.ForeignKey(
                        name: "FK_OnMooc_OnCourseDetail_OnCourseDetailId",
                        column: x => x.OnCourseDetailId,
                        principalTable: "OnCourseDetail",
                        principalColumn: "OnCourseDetailId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OnMoocDetail",
                columns: table => new
                {
                    OnMoocDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Score = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MoocDetailId = table.Column<int>(type: "int", nullable: true),
                    OnMoocId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnMoocDetail", x => x.OnMoocDetailId);
                    table.ForeignKey(
                        name: "FK_OnMoocDetail_MoocDetail_MoocDetailId",
                        column: x => x.MoocDetailId,
                        principalTable: "MoocDetail",
                        principalColumn: "MoocDetailId");
                    table.ForeignKey(
                        name: "FK_OnMoocDetail_OnMooc_OnMoocId",
                        column: x => x.OnMoocId,
                        principalTable: "OnMooc",
                        principalColumn: "OnMoocId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Coursera_TeacherId",
                table: "Coursera",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseraDetail_CourseraId",
                table: "CourseraDetail",
                column: "CourseraId");

            migrationBuilder.CreateIndex(
                name: "IX_Mooc_CourseraDetailId",
                table: "Mooc",
                column: "CourseraDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MoocDetail_MoocId",
                table: "MoocDetail",
                column: "MoocId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCourseDetail_CourseraDetailId",
                table: "OnCourseDetail",
                column: "CourseraDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCourseDetail_OnCourseId",
                table: "OnCourseDetail",
                column: "OnCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCoursera_CourseraId",
                table: "OnCoursera",
                column: "CourseraId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCoursera_StudentId",
                table: "OnCoursera",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_OnMooc_MoocId",
                table: "OnMooc",
                column: "MoocId");

            migrationBuilder.CreateIndex(
                name: "IX_OnMooc_OnCourseDetailId",
                table: "OnMooc",
                column: "OnCourseDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OnMoocDetail_MoocDetailId",
                table: "OnMoocDetail",
                column: "MoocDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OnMoocDetail_OnMoocId",
                table: "OnMoocDetail",
                column: "OnMoocId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnMoocDetail");

            migrationBuilder.DropTable(
                name: "MoocDetail");

            migrationBuilder.DropTable(
                name: "OnMooc");

            migrationBuilder.DropTable(
                name: "Mooc");

            migrationBuilder.DropTable(
                name: "OnCourseDetail");

            migrationBuilder.DropTable(
                name: "CourseraDetail");

            migrationBuilder.DropTable(
                name: "OnCoursera");

            migrationBuilder.DropTable(
                name: "Coursera");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
