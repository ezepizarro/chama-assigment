using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chama.Infrastructure.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Teachers",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "StudentSession",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Students",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Sessions",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 11, 14, 29, 32, 719, DateTimeKind.Local).AddTicks(4181), "Go from Zero", null, "Python" },
                    { 2, new DateTime(2019, 7, 11, 14, 29, 32, 719, DateTimeKind.Local).AddTicks(4201), "Beginner to Advance", null, "Net" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "CreatedDate", "Email", "FirstName", "LastName", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, 22, new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(8128), "sco@sco.com", "Scoot", "Reynolds", null },
                    { 2, 33, new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(9011), "rory@rory.com", "Rory", "Lee", null },
                    { 3, 43, new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(9019), "oli@oli.com", "Oliver", "Mendoza", null },
                    { 4, 19, new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(9020), "ai@ai.com", "Aidan", "Mayo", null },
                    { 5, 21, new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(9021), "fin@fin.com", "Finlay", "Wolf", null },
                    { 6, 23, new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(9022), "wes@wes.com", "Westin", "Rush", null },
                    { 7, 36, new DateTime(2019, 7, 11, 14, 29, 32, 717, DateTimeKind.Local).AddTicks(9023), "shay@shay.com", "Shay", "Woods", null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedDate", "FirstName", "LastName", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 11, 14, 29, 32, 719, DateTimeKind.Local).AddTicks(5666), "Sam", "Jones", null },
                    { 2, new DateTime(2019, 7, 11, 14, 29, 32, 719, DateTimeKind.Local).AddTicks(5683), "Calvin", "Mills", null }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "AvgAge", "CourseId", "CreatedDate", "MaxAge", "MaxCapacity", "MinAge", "ModifiedDate", "NumberOfStudents", "TeacherId" },
                values: new object[] { 1, 0, 1, new DateTime(2019, 7, 11, 14, 29, 32, 719, DateTimeKind.Local).AddTicks(8569), 0, 20, 0, null, 0, 1 });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "AvgAge", "CourseId", "CreatedDate", "MaxAge", "MaxCapacity", "MinAge", "ModifiedDate", "NumberOfStudents", "TeacherId" },
                values: new object[] { 2, 0, 2, new DateTime(2019, 7, 11, 14, 29, 32, 719, DateTimeKind.Local).AddTicks(8970), 0, 15, 0, null, 0, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "StudentSession",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Students",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Sessions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
