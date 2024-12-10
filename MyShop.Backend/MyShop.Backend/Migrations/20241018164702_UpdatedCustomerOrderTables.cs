using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Backend.Migrations
{
    public partial class UpdatedCustomerOrderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_order",
                table: "ProductOrder");

            migrationBuilder.DropColumn(
                name: "id_product",
                table: "ProductOrder");

            migrationBuilder.DropColumn(
                name: "id_customer",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "id_product",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_order",
                table: "ProductOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_product",
                table: "ProductOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_customer",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_product",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
