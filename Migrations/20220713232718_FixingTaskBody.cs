using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class FixingTaskBody : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Task",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Task",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb3399"),
                columns: new[] { "CreatedAt", "Description", "Priority", "Title" },
                values: new object[] { new DateTime(2022, 7, 13, 18, 27, 18, 60, DateTimeKind.Local).AddTicks(692), "This is a random Task to do, this is just some random description", 2, "Review the payment for the school." });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb4499"),
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2022, 7, 13, 18, 27, 18, 60, DateTimeKind.Local).AddTicks(748), "This is a random Task to do, this is just some random description", "Finish Stranger things Season 4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Task");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb3399"),
                column: "CreatedAt",
                value: new DateTime(2022, 7, 13, 17, 48, 25, 990, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb4499"),
                column: "CreatedAt",
                value: new DateTime(2022, 7, 13, 17, 48, 25, 990, DateTimeKind.Local).AddTicks(8102));
        }
    }
}
