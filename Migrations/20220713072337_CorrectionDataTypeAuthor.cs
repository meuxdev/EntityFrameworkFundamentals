using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class CorrectionDataTypeAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "Author",
                type: "real",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<float>(
                name: "Height",
                table: "Author",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: new Guid("5e48e5cd-0850-48f2-9b3b-572f82f0ba91"),
                columns: new[] { "Height", "Weight" },
                values: new object[] { 1.75f, 80.2f });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: new Guid("656fe592-6dd1-4108-b492-c014f1faefdc"),
                columns: new[] { "Height", "Weight" },
                values: new object[] { 1.8f, 95.3f });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb3399"),
                column: "CreatedAt",
                value: new DateTime(2022, 7, 13, 2, 23, 37, 742, DateTimeKind.Local).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb4499"),
                column: "CreatedAt",
                value: new DateTime(2022, 7, 13, 2, 23, 37, 742, DateTimeKind.Local).AddTicks(5686));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Author",
                type: "float",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Author",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: new Guid("5e48e5cd-0850-48f2-9b3b-572f82f0ba91"),
                columns: new[] { "Height", "Weight" },
                values: new object[] { 1.75, 80.0 });

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: new Guid("656fe592-6dd1-4108-b492-c014f1faefdc"),
                columns: new[] { "Height", "Weight" },
                values: new object[] { 1.8, 95.0 });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb3399"),
                column: "CreatedAt",
                value: new DateTime(2022, 7, 13, 2, 19, 20, 256, DateTimeKind.Local).AddTicks(7036));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b4c54026-ec34-439d-bb61-b3e4c1cb4499"),
                column: "CreatedAt",
                value: new DateTime(2022, 7, 13, 2, 19, 20, 256, DateTimeKind.Local).AddTicks(7084));
        }
    }
}
