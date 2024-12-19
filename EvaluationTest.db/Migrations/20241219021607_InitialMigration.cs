using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationTest.db.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_firstname = table.Column<string>(maxLength: 30, nullable: false),
                    customer_lastname = table.Column<string>(maxLength: 30, nullable: false),
                    customer_email = table.Column<string>(nullable: true),
                    customer_DOB = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(nullable: false),
                    product_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    product_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(nullable: false),
                    date_of_order = table.Column<DateTime>(nullable: false),
                    order_payment_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "Customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProductMappings",
                columns: table => new
                {
                    order_product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    product_quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductMappings", x => x.order_product_id);
                    table.ForeignKey(
                        name: "FK_OrderProductMappings_Orders_order_id",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProductMappings_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductMappings_order_id",
                table: "OrderProductMappings",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductMappings_product_id",
                table: "OrderProductMappings",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customer_id",
                table: "Orders",
                column: "customer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProductMappings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
