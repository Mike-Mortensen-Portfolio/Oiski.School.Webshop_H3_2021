using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Migrations
{
    public partial class ChangedDataSeeding30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 15);

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
                column: "Title",
                value: "High-Waisted-Jeans-Front");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 2,
                column: "Title",
                value: "High-Waisted-Jeans-Back");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 3,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 2, "Skater-Skirt-Front" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 4,
                column: "Title",
                value: "Skater-Skirt-Back");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 5,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 3, "Summer-Dress-Front" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 6,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 3, "Summer-Dress-Back" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 7,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 4, "Sneakers-Paradise-Front" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 8,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 4, "Sneakers-Paradise-Back" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 9,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 5, "Warm-Knitted-Sweater-Front" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 10,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 5, "Warm-Knitted-Sweater-Back" });
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
                column: "Title",
                value: "High-Waisted-Jeans-SideWays");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 2,
                column: "Title",
                value: "High-Waisted-Jeans-Front");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 3,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 1, "High-Waisted-Jeans-Back" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 4,
                column: "Title",
                value: "Skater-Skirt-SideWays");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 5,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 2, "Skater-Skirt-Front" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 6,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 2, "Skater-Skirt-Back" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 7,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 3, "Summer-Dress-SideWays" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 8,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 3, "Summer-Dress-Front" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 9,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 3, "Summer-Dress-Back" });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 10,
                columns: new[] { "ProductID", "Title" },
                values: new object[] { 4, "Sneakers-Paradise-SideWays" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageID", "ImageStream", "ProductID", "Title" },
                values: new object[,]
                {
                    { 14, new byte[0], 5, "Warm-Knitted-Sweater-SideWays" },
                    { 13, new byte[0], 5, "Warm-Knitted-Sweater-SideWays" },
                    { 12, new byte[0], 4, "Sneakers-Paradise-Back" },
                    { 15, new byte[0], 5, "Warm-Knitted-Sweater-SideWays" },
                    { 11, new byte[0], 4, "Sneakers-Paradise-Front" }
                });
        }
    }
}
