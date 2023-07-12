using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dockerWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUserCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "guid", "country", "email", "login", "user_name" },
                values: new object[] { new Guid("7cd56dd3-66b7-4960-aedf-cb3e9a75f542"), "Russia", "test0@mail.ru", "login0", "userName0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "guid",
                keyValue: new Guid("7cd56dd3-66b7-4960-aedf-cb3e9a75f542"));

            migrationBuilder.DropColumn(
                name: "country",
                table: "users");
        }
    }
}
