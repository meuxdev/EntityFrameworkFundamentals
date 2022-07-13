using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Importance", "Name" },
                values: new object[] { new Guid("5f617470-bf19-4be4-9fea-f26a18bf616a"), "This is a random category creating for testing the db", 20, "Pending Activities" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Importance", "Name" },
                values: new object[] { new Guid("5f617470-bf20-4be4-9fea-f26a18bf616a"), "This is a random category creating for testing the db", 50, "Studying the new formulas" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "Completed", "CreatedAt", "Description", "Priority", "Title" },
                values: new object[] { new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb3399"), new Guid("5f617470-bf19-4be4-9fea-f26a18bf616a"), false, new DateTime(2022, 7, 13, 1, 52, 1, 440, DateTimeKind.Local).AddTicks(8325), "This is a random Task to do, this is just some random description", 2, "Review the payment for the school." });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "Completed", "CreatedAt", "Description", "Priority", "Title" },
                values: new object[] { new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb4499"), new Guid("5f617470-bf20-4be4-9fea-f26a18bf616a"), false, new DateTime(2022, 7, 13, 1, 52, 1, 440, DateTimeKind.Local).AddTicks(8367), "This is a random Task to do, this is just some random description", 0, "Finish Stranger things Season 4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb3399"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb4499"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("5f617470-bf19-4be4-9fea-f26a18bf616a"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("5f617470-bf20-4be4-9fea-f26a18bf616a"));
        }
    }
}
