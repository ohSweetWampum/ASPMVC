﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPMVC.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addingImageurlToProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageURL",
                table: "myProductTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "myProductTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "imageURL",
                value: "");

            migrationBuilder.UpdateData(
                table: "myProductTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "imageURL",
                value: "");

            migrationBuilder.UpdateData(
                table: "myProductTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "imageURL",
                value: "");

            migrationBuilder.UpdateData(
                table: "myProductTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "imageURL",
                value: "");

            migrationBuilder.UpdateData(
                table: "myProductTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "imageURL",
                value: "");

            migrationBuilder.UpdateData(
                table: "myProductTable",
                keyColumn: "Id",
                keyValue: 6,
                column: "imageURL",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageURL",
                table: "myProductTable");
        }
    }
}
