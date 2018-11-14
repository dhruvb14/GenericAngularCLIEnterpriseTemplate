using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brownbag.Data.Migrations
{
    public partial class AddDeveloperRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f71"), "d6775817-bb1a-4d77-8ed7-1d430c91d7f1", "Developer", "DEVELOPER" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f71") });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 72, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 74, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 74, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 74, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 74, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 74, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 76, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 76, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 76, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 76, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 76, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 76, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 76, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 76, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 13, 15, 59, 7, 76, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f71"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f71") });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 566, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 569, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 569, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 569, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 569, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 569, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local));
        }
    }
}
