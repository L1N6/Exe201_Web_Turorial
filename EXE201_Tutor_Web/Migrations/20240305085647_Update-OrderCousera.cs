using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXE201_Tutor_Web.Migrations
{
    public partial class UpdateOrderCousera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseraId",
                table: "OrderCourseras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderCourseras_CourseraId",
                table: "OrderCourseras",
                column: "CourseraId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCourseras_Courseras_CourseraId",
                table: "OrderCourseras",
                column: "CourseraId",
                principalTable: "Courseras",
                principalColumn: "CourseraId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderCourseras_Courseras_CourseraId",
                table: "OrderCourseras");

            migrationBuilder.DropIndex(
                name: "IX_OrderCourseras_CourseraId",
                table: "OrderCourseras");

            migrationBuilder.DropColumn(
                name: "CourseraId",
                table: "OrderCourseras");
        }
    }
}
