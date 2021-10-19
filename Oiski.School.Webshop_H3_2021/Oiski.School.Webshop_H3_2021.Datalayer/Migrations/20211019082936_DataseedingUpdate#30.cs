using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Migrations
{
    public partial class DataseedingUpdate30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "BrandName", "Description", "InStock", "Price", "Title" },
                values: new object[,]
                {
                    { 6, "Nike Air", "Perfect for the daily life.", 180, 52m, "Simple Sneakers" },
                    { 7, "H&M Basic", "Style it however you'd want to!", 256, 15m, "Simple T-shirt" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeID", "Name" },
                values: new object[,]
                {
                    { 10, "T-shirt" },
                    { 11, "Upper-wear" },
                    { 12, "Bottom" },
                    { 13, "Full-body" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "ProductID", "TypeID" },
                values: new object[,]
                {
                    { 6, 6 },
                    { 6, 7 },
                    { 7, 8 },
                    { 5, 11 },
                    { 7, 11 },
                    { 1, 12 },
                    { 2, 12 },
                    { 3, 13 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 7, 11 });

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 13);

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
        }
    }
}
