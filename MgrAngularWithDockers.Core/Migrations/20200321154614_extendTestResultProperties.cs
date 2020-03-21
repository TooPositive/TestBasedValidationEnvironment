using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgrAngularWithDockers.Core.Migrations
{
    public partial class extendTestResultProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExecutionTime",
                table: "TestResults",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TestDuration",
                table: "TestResults",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExecutionTime",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "TestDuration",
                table: "TestResults");
        }
    }
}
