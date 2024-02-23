using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201_Tutor_Web_API.Migrations
{
    public partial class DB_EXE201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "MoocDetail",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "Mooc",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "CourseraDetail",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "Coursera",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "MoocDetail");

            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "Mooc");

            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "CourseraDetail");

            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "Coursera");
        }
    }
}
