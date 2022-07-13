using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class AuthorInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Task",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<long>(type: "bigint", maxLength: 120, nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "AuthorId", "Age", "Height", "Name", "Weight" },
                values: new object[] { new Guid("5e48e5cd-0850-48f2-9b3b-572f82f0ba91"), 24L, 1.75, "Alejandro", 80.0 });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "AuthorId", "Age", "Height", "Name", "Weight" },
                values: new object[] { new Guid("656fe592-6dd1-4108-b492-c014f1faefdc"), 40L, 1.8, "Josh", 95.0 });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb3399"),
                columns: new[] { "AuthorId", "CreatedAt" },
                values: new object[] { new Guid("5e48e5cd-0850-48f2-9b3b-572f82f0ba91"), new DateTime(2022, 7, 13, 2, 19, 20, 256, DateTimeKind.Local).AddTicks(7036) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb4499"),
                columns: new[] { "AuthorId", "CreatedAt" },
                values: new object[] { new Guid("656fe592-6dd1-4108-b492-c014f1faefdc"), new DateTime(2022, 7, 13, 2, 19, 20, 256, DateTimeKind.Local).AddTicks(7084) });

            migrationBuilder.CreateIndex(
                name: "IX_Task_AuthorId",
                table: "Task",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Author_AuthorId",
                table: "Task",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Author_AuthorId",
                table: "Task");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Task_AuthorId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Task");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb3399"),
                column: "CreatedAt",
                value: new DateTime(2022, 7, 13, 1, 52, 1, 440, DateTimeKind.Local).AddTicks(8325));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb4499"),
                column: "CreatedAt",
                value: new DateTime(2022, 7, 13, 1, 52, 1, 440, DateTimeKind.Local).AddTicks(8367));
        }
    }
}
