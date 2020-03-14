using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgrAngularWithDockers.Migrations
{
    public partial class testresultChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_TestResults_ResultGuid",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_ResultGuid",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "ResultGuid",
                table: "TestResults");

            migrationBuilder.AddColumn<int>(
                name: "Result",
                table: "TestResults",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "TestResults");

            migrationBuilder.AddColumn<Guid>(
                name: "ResultGuid",
                table: "TestResults",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_ResultGuid",
                table: "TestResults",
                column: "ResultGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_TestResults_ResultGuid",
                table: "TestResults",
                column: "ResultGuid",
                principalTable: "TestResults",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
