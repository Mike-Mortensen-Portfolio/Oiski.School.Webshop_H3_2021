using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    ISDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageID);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeOfPayment = table.Column<int>(type: "int", nullable: false),
                    TypeOfDelivery = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.ProductID, x.OrderID });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandID", "Name" },
                values: new object[,]
                {
                    { 1, "H&M" },
                    { 2, "NA-KD" },
                    { 3, "Nike" },
                    { 4, "ASOS" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Upper body" },
                    { 2, "Lower body" },
                    { 3, "Full body" },
                    { 4, "Footwear" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "City", "Country", "Email", "FirstName", "LastName", "PhoneNumber", "UserID", "ZipCode" },
                values: new object[] { 4, "Nordre Ringvej 20", "Vojens", "Denmark", "ullelarsen@gmail.com", "Ulrik", "Larsen", "25496875", null, 6500 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CustomerID", "IsAdmin", "Password" },
                values: new object[,]
                {
                    { 1, 2, true, "P@ssw0rd" },
                    { 2, 3, false, "P@ssw0rd" },
                    { 3, 1, true, "P@ssw0rd" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "City", "Country", "Email", "FirstName", "LastName", "PhoneNumber", "UserID", "ZipCode" },
                values: new object[,]
                {
                    { 2, "Ringgade 65", "Sønderborg", "Denmark", "zhakalen@gmail.com", "Mike", "Mortensen", "25987658", 1, 6400 },
                    { 3, "Nordre Ringvej 20", "Vojens", "Denmark", "ulrikLarsen@gmail.com", "Ulrik", "Larsen", "25496875", 2, 6500 },
                    { 1, "Nygade 38A, 2", "Aabenraa", "Denmark", "jasminnielsen97@gmail.com", "Jasmin", "Nielsen", "26139596", 3, 6200 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "BrandID", "CategoryID", "Description", "ISDeleted", "InStock", "Price", "Title" },
                values: new object[,]
                {
                    { 5, 1, 1, "Drink a warm cup of chocolate while cozing up in this sweater.", false, 109, 28m, "Warm knitted-sweater" },
                    { 7, 1, 1, "Style it however you'd want to!", false, 256, 15m, "Simple T-shirt" },
                    { 1, 1, 2, "These pants are great for the Autumn weather.", false, 125, 40.58m, "High-waisted jeans" },
                    { 2, 2, 2, "The perfect outfit for your lower body.", false, 50, 26.25m, "Skater skirt" },
                    { 3, 4, 3, "Beer parties on the beach? This is your dress.", false, 75, 53.75m, "Summer dress" },
                    { 4, 3, 4, "Love long walks? Choose these sneakers.", false, 130, 88m, "Sneakers paradise, Nike" },
                    { 6, 3, 4, "Perfect for the daily life.", false, 180, 52m, "Simple Sneakers, Nike Air" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "OrderDate", "TypeOfDelivery", "TypeOfPayment" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 2, 1, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageID", "ImageURL", "ProductID", "Title" },
                values: new object[,]
                {
                    { 9, "Clothes/Top/Warm-Knitted-Sweater-Front.jpg", 5, "Warm-Knitted-Sweater-Front" },
                    { 10, "Clothes/Top/Warm-Knitted-Sweater-Back.jpg", 5, "Warm-Knitted-Sweater-Back" },
                    { 13, "Clothes/Top/Simple-T-shirt-Front.jpg", 7, "Simple-T-shirt-Front" },
                    { 14, "Clothes/Top/Simple-T-shirt-Back.jpg", 7, "Simple-T-shirt-Back" },
                    { 1, "Clothes/Bottoms/High-Waisted-Jeans-Front.jpg", 1, "High-Waisted-Jeans-Front" },
                    { 2, "Clothes/Bottoms/High-Waisted-Jeans-Back.jpg", 1, "High-Waisted-Jeans-Back" },
                    { 3, "Clothes/Bottoms/Skater-Skirt-Front.jpg", 2, "Skater-Skirt-Front" },
                    { 4, "Clothes/Bottoms/Skater-Skirt-Back.jpg", 2, "Skater-Skirt-Back" },
                    { 5, "Clothes/FullBody/Summer-Dress-Front.jpg", 3, "Summer-Dress-Front" },
                    { 6, "Clothes/FullBody/Summer-Dress-Back.jpg", 3, "Summer-Dress-Back" },
                    { 7, "Clothes/Shoes/Sneakers-Paradise-Front.jpg", 4, "Sneakers-Paradise-Front" },
                    { 8, "Clothes/Shoes/Sneakers-Paradise-Back.jpg", 4, "Sneakers-Paradise-Back" },
                    { 11, "Clothes/Shoes/Simple-Sneakers-Front.jpg", 6, "Simple-Sneakersle-Front" },
                    { 12, "Clothes/Shoes/Simple-Sneakers-Back.jpg", 6, "Simple-Sneakers-Back" }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderID", "ProductID", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 1, 4, 0 },
                    { 1, 5, 0 },
                    { 2, 2, 0 },
                    { 2, 3, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserID",
                table: "Customers",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderID",
                table: "OrderProducts",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImages",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandID",
                table: "Products",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
