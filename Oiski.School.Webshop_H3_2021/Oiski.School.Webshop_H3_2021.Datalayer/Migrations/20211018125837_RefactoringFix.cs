using Microsoft.EntityFrameworkCore.Migrations;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Migrations
{
    public partial class RefactoringFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_CustomerLoginID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerLoginID",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerLoginID",
                table: "Customers",
                newName: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserID",
                table: "Customers",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserID",
                table: "Customers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserID",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Customers",
                newName: "CustomerLoginID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerLoginID",
                table: "Customers",
                column: "CustomerLoginID",
                unique: true,
                filter: "[CustomerLoginID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_CustomerLoginID",
                table: "Customers",
                column: "CustomerLoginID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
