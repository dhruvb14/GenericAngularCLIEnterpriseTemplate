using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brownbag.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f78"), "d6775817-bb1a-4d77-8ed7-1d430c91d7f1", "User", "USER" },
                    { new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f79"), "d6775817-bb1a-4d77-8ed7-1d430c91d7f1", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserFullName", "UserName" },
                values: new object[] { new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), 0, "a179afd9-9b34-4713-8295-a1505340cec7", null, false, true, null, null, "MICROSOFT\\DHRUV", "", null, false, "d6775817-bb1a-4d77-8ed7-1d430c91d7f1", false, "Dhruv Bhavsar", "Microsoft\\dhruv" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Rating", "UpdatedBy", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 566, DateTimeKind.Local), 10, null, null, "www.microsoft.com" },
                    { 2, new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 569, DateTimeKind.Local), 9, null, null, "www.microsoft.net" },
                    { 3, new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 569, DateTimeKind.Local), 8, null, null, "www.microsoft.org" },
                    { 4, new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 569, DateTimeKind.Local), 7, null, null, "www.google.com" },
                    { 5, new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 569, DateTimeKind.Local), 6, null, null, "www.google.org" },
                    { 6, new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 569, DateTimeKind.Local), 5, null, null, "www.google.net" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f79") },
                    { new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f78") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "BlogId", "Content", "CreatedBy", "CreatedDate", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, "Test Content", new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local), "Post 1", null, null },
                    { 2, 1, "Test Content", new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local), "Post 2", null, null },
                    { 3, 1, "Test Content", new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local), "Post 3", null, null },
                    { 4, 2, "Test Content", new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local), "Post 4", null, null },
                    { 5, 2, "Test Content", new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local), "Post 5", null, null },
                    { 6, 3, "Test Content", new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local), "Post 6", null, null },
                    { 7, 4, "Test Content", new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local), "Post 7", null, null },
                    { 8, 5, "Test Content", new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local), "Post 8", null, null },
                    { 9, 6, "Test Content", new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new DateTime(2018, 11, 8, 11, 29, 52, 570, DateTimeKind.Local), "Post 9", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f78"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f79"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f78") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"), new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f79") });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c91c203-6dc2-4428-87fb-cc60a5300f72"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
