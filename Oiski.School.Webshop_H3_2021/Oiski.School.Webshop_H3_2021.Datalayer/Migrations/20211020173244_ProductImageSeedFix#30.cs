using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Migrations
{
    public partial class ProductImageSeedFix30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2021, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2021, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 1,
                column: "ImageURL",
                value: "Clothes/Bottoms/High-Waisted-Jeans-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 2,
                column: "ImageURL",
                value: "Clothes/Bottoms/High-Waisted-Jeans-Back.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 3,
                column: "ImageURL",
                value: "Clothes/Bottoms/Skater-Skirt-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 4,
                column: "ImageURL",
                value: "Clothes/Bottoms/Skater-Skirt-Back.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 5,
                column: "ImageURL",
                value: "Clothes/FullBody/Summer-Dress-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 6,
                column: "ImageURL",
                value: "Clothes/FullBody/Summer-Dress-Back.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 7,
                column: "ImageURL",
                value: "Clothes/Shoes/Sneakers-Paradise-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 8,
                column: "ImageURL",
                value: "Clothes/Shoes/Sneakers-Paradise-Back.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 9,
                column: "ImageURL",
                value: "Clothes/Top/Warm-Knitted-Sweater-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 10,
                column: "ImageURL",
                value: "Clothes/Top/Warm-Knitted-Sweater-Back.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 11,
                column: "ImageURL",
                value: "Clothes/Shoes/Simple-Sneakers-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 12,
                column: "ImageURL",
                value: "Clothes/Shoes/Simple-Sneakers-Back.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 13,
                column: "ImageURL",
                value: "Clothes/Top/Simple-T-shirt-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 14,
                column: "ImageURL",
                value: "Clothes/Top/Simple-T-shirt-Back.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 1,
                column: "ImageURL",
                value: "./Images/Clothes/Bottoms/High-Waisted-Jeans-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 2,
                column: "ImageURL",
                value: "./Images/Clothes/Bottoms/High-Waisted-Jeans-Back.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 3,
                column: "ImageURL",
                value: "./Images/Clothes/Bottoms/Skater-Skirt-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 4,
                column: "ImageURL",
                value: "./Images/Clothes/Bottoms/Skater-Skirt-Back.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 5,
                column: "ImageURL",
                value: "./Images/Clothes/FullBody/Summer-Dress-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 6,
                column: "ImageURL",
                value: "./Images/Clothes/FullBody/Summer-Dress-Back.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 7,
                column: "ImageURL",
                value: "./Images/Clothes/Shoes/Sneakers-Paradise-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 8,
                column: "ImageURL",
                value: "./Images/Clothes/Shoes/Sneakers-Paradise-Back.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 9,
                column: "ImageURL",
                value: "./Images/Clothes/Top/Warm-Knitted-Sweater-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 10,
                column: "ImageURL",
                value: "./Images/Clothes/Top/Warm-Knitted-Sweater-Back.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 11,
                column: "ImageURL",
                value: "./Images/Clothes/Shoes/Simple-Sneakersle-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 12,
                column: "ImageURL",
                value: "./Images/Clothes/Shoes/Simple-Sneakers-Back.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 13,
                column: "ImageURL",
                value: "./Images/Clothes/Top/Simple-T-shirt-Front.jpg");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 14,
                column: "ImageURL",
                value: "./Images/Clothes/Top/Simple-T-shirt-Back.jpg");
        }
    }
}
