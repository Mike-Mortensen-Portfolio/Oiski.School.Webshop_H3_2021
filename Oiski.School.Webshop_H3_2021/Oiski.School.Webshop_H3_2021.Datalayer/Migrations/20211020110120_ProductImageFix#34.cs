using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Migrations
{
    public partial class ProductImageFix34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageStream",
                table: "ProductImages");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 1, 1 },
                column: "Quantity",
                value: 2);

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

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageID", "ImageURL", "ProductID", "Title" },
                values: new object[,]
                {
                    { 14, "./Images/Clothes/Top/Simple-T-shirt-Back.jpg", 7, "Simple-T-shirt-Back" },
                    { 13, "./Images/Clothes/Top/Simple-T-shirt-Front.jpg", 7, "Simple-T-shirt-Front" },
                    { 12, "./Images/Clothes/Shoes/Simple-Sneakers-Back.jpg", 6, "Simple-Sneakers-Back" },
                    { 11, "./Images/Clothes/Shoes/Simple-Sneakersle-Front.jpg", 6, "Simple-Sneakersle-Front" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "Title",
                value: "Sneakers paradise, Nike");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                columns: new[] { "BrandName", "Title" },
                values: new object[] { "Nike", "Simple Sneakers, Nike Air" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 14);

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "ProductImages");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageStream",
                table: "ProductImages",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 1, 1 },
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 1,
                column: "ImageStream",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 2,
                column: "ImageStream",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 3,
                column: "ImageStream",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 4,
                column: "ImageStream",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 5,
                column: "ImageStream",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 6,
                column: "ImageStream",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 7,
                column: "ImageStream",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 8,
                column: "ImageStream",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 9,
                column: "ImageStream",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 10,
                column: "ImageStream",
                value: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "Title",
                value: "Sneakers paradise");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6,
                columns: new[] { "BrandName", "Title" },
                values: new object[] { "Nike Air", "Simple Sneakers" });
        }
    }
}
