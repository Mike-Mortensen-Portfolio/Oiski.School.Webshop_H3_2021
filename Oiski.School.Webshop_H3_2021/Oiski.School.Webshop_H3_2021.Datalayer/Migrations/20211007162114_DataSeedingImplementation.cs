using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Migrations
{
    public partial class DataSeedingImplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomerLogins",
                columns: new[] { "CustomerLoginID", "CustomerID", "Password" },
                values: new object[,]
                {
                    { 1, 2, "P@ssw0rd" },
                    { 2, 3, "P@ssw0rd" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "City", "Country", "CustomerLoginID", "DeliveryType", "Email", "FirstName", "LastName", "PaymentMethod", "PhoneNumber", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Nygade 38A, 2", "Aabenraa", "Denmark", null, 0, "jasminnielsen97@gmail.com", "Jasmin", "Nielsen", 0, "26139596", 6200 },
                    { 2, "Ringgade 65", "Sønderborg", "Denmark", null, 0, "zhakalen@gmail.com", "Mike", "Mortensen", 0, "25987658", 6400 },
                    { 3, "Nordre Ringvej 20", "Vojens", "Denmark", null, 0, "ulrikLarsen@gmail.com", "Ulrik", "Larsen", 0, "25496875", 6500 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "BrandName", "Description", "InStock", "Price", "Title" },
                values: new object[,]
                {
                    { 4, "Nike", "Love long walks? Choose these sneakers.", 130, 88m, "Sneakers paradise" },
                    { 3, "NA-KD", "Beer parties on the beach? This is your dress.", 75, 53.75m, "Summer dress" },
                    { 5, "H&M", "Drink a warm cup of chocolate while cozing up in this sweater.", 109, 28m, "Warm knitted-sweater" },
                    { 1, "New Look", "These pants are great for the Autumn weather.", 125, 40.58m, "High-waisted jeans" },
                    { 2, "TopShop", "The perfect outfit for your lower body.", 50, 26.25m, "Skater skirt" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeID", "Name" },
                values: new object[,]
                {
                    { 8, "Sweater" },
                    { 1, "Jeans" },
                    { 2, "Skirt" },
                    { 3, "Skater-Skirt" },
                    { 4, "Dress" },
                    { 5, "Short-Dress" },
                    { 6, "Footwear" },
                    { 7, "Sneakers" },
                    { 9, "Knitted-Sweater" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "OrderDate" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2021, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2021, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageID", "ImageStream", "ProductID", "Title" },
                values: new object[,]
                {
                    { 15, new byte[0], 5, "Warm-Knitted-Sweater-SideWays" },
                    { 14, new byte[0], 5, "Warm-Knitted-Sweater-SideWays" },
                    { 13, new byte[0], 5, "Warm-Knitted-Sweater-SideWays" },
                    { 12, new byte[0], 4, "Sneakers-Paradise-Back" },
                    { 10, new byte[0], 4, "Sneakers-Paradise-SideWays" },
                    { 9, new byte[0], 3, "Summer-Dress-Back" },
                    { 8, new byte[0], 3, "Summer-Dress-Front" },
                    { 11, new byte[0], 4, "Sneakers-Paradise-Front" },
                    { 6, new byte[0], 2, "Skater-Skirt-Back" },
                    { 5, new byte[0], 2, "Skater-Skirt-Front" },
                    { 4, new byte[0], 2, "Skater-Skirt-SideWays" },
                    { 3, new byte[0], 1, "High-Waisted-Jeans-Back" },
                    { 2, new byte[0], 1, "High-Waisted-Jeans-Front" },
                    { 1, new byte[0], 1, "High-Waisted-Jeans-SideWays" },
                    { 7, new byte[0], 3, "Summer-Dress-SideWays" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "ProductID", "TypeID" },
                values: new object[,]
                {
                    { 5, 8 },
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 5, 9 }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderID", "ProductID" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 3 },
                    { 1, 1 },
                    { 1, 4 },
                    { 1, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerLogins",
                keyColumn: "CustomerLoginID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerLogins",
                keyColumn: "CustomerLoginID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderID", "ProductID" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 10);

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

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumns: new[] { "ProductID", "TypeID" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "TypeID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 2);
        }
    }
}
