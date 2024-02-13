using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201_Tutor_Web_API.Migrations
{
    public partial class Update_Database_12022024_11h02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Coursera");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "OnMoocId",
                table: "OnMoocDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MoocDetailId",
                table: "OnMoocDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OnCourseDetailId",
                table: "OnMooc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MoocId",
                table: "OnMooc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OnCourseId",
                table: "OnCourseDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseraDetailId",
                table: "OnCourseDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "OnCourse",
                columns: table => new
                {
                    OnCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CourseraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnCourse", x => x.OnCourseId);
                    table.ForeignKey(
                        name: "FK_OnCourse_Coursera_CourseraId",
                        column: x => x.CourseraId,
                        principalTable: "Coursera",
                        principalColumn: "CourseraId");
                    table.ForeignKey(
                        name: "FK_OnCourse_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnMoocDetail_MoocDetailId",
                table: "OnMoocDetail",
                column: "MoocDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OnMoocDetail_OnMoocId",
                table: "OnMoocDetail",
                column: "OnMoocId");

            migrationBuilder.CreateIndex(
                name: "IX_OnMooc_MoocId",
                table: "OnMooc",
                column: "MoocId");

            migrationBuilder.CreateIndex(
                name: "IX_OnMooc_OnCourseDetailId",
                table: "OnMooc",
                column: "OnCourseDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCourseDetail_CourseraDetailId",
                table: "OnCourseDetail",
                column: "CourseraDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCourseDetail_OnCourseId",
                table: "OnCourseDetail",
                column: "OnCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_MoocDetail_MoocId",
                table: "MoocDetail",
                column: "MoocId");

            migrationBuilder.CreateIndex(
                name: "IX_Mooc_CourseraDetailId",
                table: "Mooc",
                column: "CourseraDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseraDetail_CourseraId",
                table: "CourseraDetail",
                column: "CourseraId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCourse_CourseraId",
                table: "OnCourse",
                column: "CourseraId");

            migrationBuilder.CreateIndex(
                name: "IX_OnCourse_UserId",
                table: "OnCourse",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseraDetail_Coursera_CourseraId",
                table: "CourseraDetail",
                column: "CourseraId",
                principalTable: "Coursera",
                principalColumn: "CourseraId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mooc_CourseraDetail_CourseraDetailId",
                table: "Mooc",
                column: "CourseraDetailId",
                principalTable: "CourseraDetail",
                principalColumn: "CourseraDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoocDetail_Mooc_MoocId",
                table: "MoocDetail",
                column: "MoocId",
                principalTable: "Mooc",
                principalColumn: "MoocId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnCourseDetail_CourseraDetail_CourseraDetailId",
                table: "OnCourseDetail",
                column: "CourseraDetailId",
                principalTable: "CourseraDetail",
                principalColumn: "CourseraDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnCourseDetail_OnCourse_OnCourseId",
                table: "OnCourseDetail",
                column: "OnCourseId",
                principalTable: "OnCourse",
                principalColumn: "OnCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnMooc_Mooc_MoocId",
                table: "OnMooc",
                column: "MoocId",
                principalTable: "Mooc",
                principalColumn: "MoocId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnMooc_OnCourseDetail_OnCourseDetailId",
                table: "OnMooc",
                column: "OnCourseDetailId",
                principalTable: "OnCourseDetail",
                principalColumn: "OnCourseDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnMoocDetail_MoocDetail_MoocDetailId",
                table: "OnMoocDetail",
                column: "MoocDetailId",
                principalTable: "MoocDetail",
                principalColumn: "MoocDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnMoocDetail_OnMooc_OnMoocId",
                table: "OnMoocDetail",
                column: "OnMoocId",
                principalTable: "OnMooc",
                principalColumn: "OnMoocId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseraDetail_Coursera_CourseraId",
                table: "CourseraDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Mooc_CourseraDetail_CourseraDetailId",
                table: "Mooc");

            migrationBuilder.DropForeignKey(
                name: "FK_MoocDetail_Mooc_MoocId",
                table: "MoocDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OnCourseDetail_CourseraDetail_CourseraDetailId",
                table: "OnCourseDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OnCourseDetail_OnCourse_OnCourseId",
                table: "OnCourseDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OnMooc_Mooc_MoocId",
                table: "OnMooc");

            migrationBuilder.DropForeignKey(
                name: "FK_OnMooc_OnCourseDetail_OnCourseDetailId",
                table: "OnMooc");

            migrationBuilder.DropForeignKey(
                name: "FK_OnMoocDetail_MoocDetail_MoocDetailId",
                table: "OnMoocDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OnMoocDetail_OnMooc_OnMoocId",
                table: "OnMoocDetail");

            migrationBuilder.DropTable(
                name: "OnCourse");

            migrationBuilder.DropIndex(
                name: "IX_OnMoocDetail_MoocDetailId",
                table: "OnMoocDetail");

            migrationBuilder.DropIndex(
                name: "IX_OnMoocDetail_OnMoocId",
                table: "OnMoocDetail");

            migrationBuilder.DropIndex(
                name: "IX_OnMooc_MoocId",
                table: "OnMooc");

            migrationBuilder.DropIndex(
                name: "IX_OnMooc_OnCourseDetailId",
                table: "OnMooc");

            migrationBuilder.DropIndex(
                name: "IX_OnCourseDetail_CourseraDetailId",
                table: "OnCourseDetail");

            migrationBuilder.DropIndex(
                name: "IX_OnCourseDetail_OnCourseId",
                table: "OnCourseDetail");

            migrationBuilder.DropIndex(
                name: "IX_MoocDetail_MoocId",
                table: "MoocDetail");

            migrationBuilder.DropIndex(
                name: "IX_Mooc_CourseraDetailId",
                table: "Mooc");

            migrationBuilder.DropIndex(
                name: "IX_CourseraDetail_CourseraId",
                table: "CourseraDetail");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "OnMoocId",
                table: "OnMoocDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MoocDetailId",
                table: "OnMoocDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OnCourseDetailId",
                table: "OnMooc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MoocId",
                table: "OnMooc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OnCourseId",
                table: "OnCourseDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseraDetailId",
                table: "OnCourseDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Coursera",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
