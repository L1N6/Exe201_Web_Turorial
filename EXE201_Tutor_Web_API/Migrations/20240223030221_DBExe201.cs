using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201_Tutor_Web_API.Migrations
{
    public partial class DBExe201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Coursera",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Coursera",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HashTag",
                table: "Coursera",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Coursera",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "Coursera",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TotalDate",
                table: "Coursera",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Coursera");

            migrationBuilder.DropColumn(
                name: "HashTag",
                table: "Coursera");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Coursera");

            migrationBuilder.DropColumn(
                name: "Major",
                table: "Coursera");

            migrationBuilder.DropColumn(
                name: "TotalDate",
                table: "Coursera");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Coursera",
                newName: "Date");
        }
    }
}
