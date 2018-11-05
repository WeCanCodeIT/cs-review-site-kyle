using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewsSite.Migrations
{
    public partial class ReviewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "Date", "ImageUrl", "ReviewCategory", "Title" },
                values: new object[] { 1, "It was an ok movie, I guess.", new DateTime(2010, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/spiderman.jpg", "Action", "Spiderman" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "Date", "ImageUrl", "ReviewCategory", "Title" },
                values: new object[] { 2, "It was great-ish", new DateTime(2009, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/batman.jpg", "Action", "Batman" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "Date", "ImageUrl", "ReviewCategory", "Title" },
                values: new object[] { 3, "It was a awesome!", new DateTime(2008, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/xmen.jpg", "Action", "X-Men" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
