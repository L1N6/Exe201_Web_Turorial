using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201_Tutor_Web.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
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
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avatar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avatar = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courseras",
                columns: table => new
                {
                    CourseraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TotalDate = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Major = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HashTag = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courseras", x => x.CourseraId);
                    table.ForeignKey(
                        name: "FK_Courseras_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseraDetails",
                columns: table => new
                {
                    CourseraDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseraId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseraDetails", x => x.CourseraDetailId);
                    table.ForeignKey(
                        name: "FK_CourseraDetails_Courseras_CourseraId",
                        column: x => x.CourseraId,
                        principalTable: "Courseras",
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
                        name: "FK_OnCoursera_Courseras_CourseraId",
                        column: x => x.CourseraId,
                        principalTable: "Courseras",
                        principalColumn: "CourseraId");
                    table.ForeignKey(
                        name: "FK_OnCoursera_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Moocs",
                columns: table => new
                {
                    MoocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseraDetailId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MinScore = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moocs", x => x.MoocId);
                    table.ForeignKey(
                        name: "FK_Moocs_CourseraDetails_CourseraDetailId",
                        column: x => x.CourseraDetailId,
                        principalTable: "CourseraDetails",
                        principalColumn: "CourseraDetailId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OnCourseDetails",
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
                    table.PrimaryKey("PK_OnCourseDetails", x => x.OnCourseDetailId);
                    table.ForeignKey(
                        name: "FK_OnCourseDetails_CourseraDetails_CourseraDetailId",
                        column: x => x.CourseraDetailId,
                        principalTable: "CourseraDetails",
                        principalColumn: "CourseraDetailId");
                    table.ForeignKey(
                        name: "FK_OnCourseDetails_OnCoursera_OnCourseId",
                        column: x => x.OnCourseId,
                        principalTable: "OnCoursera",
                        principalColumn: "OnCourseId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MoocDetails",
                columns: table => new
                {
                    MoocDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MoocId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeName = table.Column<string>(type: "longtext", nullable: true)
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
                    table.PrimaryKey("PK_MoocDetails", x => x.MoocDetailId);
                    table.ForeignKey(
                        name: "FK_MoocDetails_Moocs_MoocId",
                        column: x => x.MoocId,
                        principalTable: "Moocs",
                        principalColumn: "MoocId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OnMoocs",
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
                    table.PrimaryKey("PK_OnMoocs", x => x.OnMoocId);
                    table.ForeignKey(
                        name: "FK_OnMoocs_Moocs_MoocId",
                        column: x => x.MoocId,
                        principalTable: "Moocs",
                        principalColumn: "MoocId");
                    table.ForeignKey(
                        name: "FK_OnMoocs_OnCourseDetails_OnCourseDetailId",
                        column: x => x.OnCourseDetailId,
                        principalTable: "OnCourseDetails",
                        principalColumn: "OnCourseDetailId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OnMoocDetails",
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
                    table.PrimaryKey("PK_OnMoocDetails", x => x.OnMoocDetailId);
                    table.ForeignKey(
                        name: "FK_OnMoocDetails_MoocDetails_MoocDetailId",
                        column: x => x.MoocDetailId,
                        principalTable: "MoocDetails",
                        principalColumn: "MoocDetailId");
                    table.ForeignKey(
                        name: "FK_OnMoocDetails_OnMoocs_OnMoocId",
                        column: x => x.OnMoocId,
                        principalTable: "OnMoocs",
                        principalColumn: "OnMoocId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CourseraDetails_CourseraId",
                table: "CourseraDetails",
                column: "CourseraId");

            migrationBuilder.CreateIndex(
                name: "IX_Courseras_TeacherId",
                table: "Courseras",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_MoocDetails_MoocId",
                table: "MoocDetails",
                column: "MoocId");

            migrationBuilder.CreateIndex(
                name: "IX_Moocs_CourseraDetailId",
                table: "Moocs",
                column: "CourseraDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCourseDetails_CourseraDetailId",
                table: "OnCourseDetails",
                column: "CourseraDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCourseDetails_OnCourseId",
                table: "OnCourseDetails",
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
                name: "IX_OnMoocDetails_MoocDetailId",
                table: "OnMoocDetails",
                column: "MoocDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OnMoocDetails_OnMoocId",
                table: "OnMoocDetails",
                column: "OnMoocId");

            migrationBuilder.CreateIndex(
                name: "IX_OnMoocs_MoocId",
                table: "OnMoocs",
                column: "MoocId");

            migrationBuilder.CreateIndex(
                name: "IX_OnMoocs_OnCourseDetailId",
                table: "OnMoocs",
                column: "OnCourseDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnMoocDetails");

            migrationBuilder.DropTable(
                name: "MoocDetails");

            migrationBuilder.DropTable(
                name: "OnMoocs");

            migrationBuilder.DropTable(
                name: "Moocs");

            migrationBuilder.DropTable(
                name: "OnCourseDetails");

            migrationBuilder.DropTable(
                name: "CourseraDetails");

            migrationBuilder.DropTable(
                name: "OnCoursera");

            migrationBuilder.DropTable(
                name: "Courseras");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
