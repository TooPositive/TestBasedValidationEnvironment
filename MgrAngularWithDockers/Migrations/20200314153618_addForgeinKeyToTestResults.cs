using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgrAngularWithDockers.Migrations
{
    public partial class addForgeinKeyToTestResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestResults",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    ResultGuid = table.Column<Guid>(nullable: true),
                    TestGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_TestResults_TestResults_ResultGuid",
                        column: x => x.ResultGuid,
                        principalTable: "TestResults",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestResults_Tests_TestGuid",
                        column: x => x.TestGuid,
                        principalTable: "Tests",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_ResultGuid",
                table: "TestResults",
                column: "ResultGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_TestGuid",
                table: "TestResults",
                column: "TestGuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestResults");
        }
    }
}
