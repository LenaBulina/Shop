using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Backend.Migrations
{
    public partial class UpdatedManyToManyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_Customerid",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ProductOrder");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Orders",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "payment",
                table: "Orders",
                newName: "Payment");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Orders",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Customerid",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Customerid",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Customers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Customers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Customers",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => new { x.OrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductsId",
                table: "ProductOrders",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Orders",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Payment",
                table: "Orders",
                newName: "payment");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Orders",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "Customerid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_Customerid");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Customers",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "ProductOrder",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orderid = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrder", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductOrder_Orders_Orderid",
                        column: x => x.Orderid,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrder_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_Orderid",
                table: "ProductOrder",
                column: "Orderid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_ProductId",
                table: "ProductOrder",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_Customerid",
                table: "Orders",
                column: "Customerid",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
