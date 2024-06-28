using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuntoDeVenta_Api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CATEGORI__19093A0B5132E779", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENTMETHODS",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PAYMENTM__DC31C1D351B7B089", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "SUPLIERS",
                columns: table => new
                {
                    SuplierId = table.Column<int>(type: "int", nullable: false),
                    SuplierName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SUPLIERS__1AD74ADD3FD3A0B6", x => x.SuplierId);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PRODUCTS__B40CC6CD3AD54279", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK__PRODUCTS__Catego__440B1D61",
                        column: x => x.CategoryId,
                        principalTable: "CATEGORIES",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "SALES",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SaleTotal = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SALES__1EE3C3FFA2BAB9F2", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK__SALES__PaymentMe__48CFD27E",
                        column: x => x.PaymentMethodId,
                        principalTable: "PAYMENTMETHODS",
                        principalColumn: "PaymentMethodId");
                });

            migrationBuilder.CreateTable(
                name: "PURCHASES",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    SuplierId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalPurchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PURCHASE__6B0A6BBE44DAE336", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK__PURCHASES__Supli__5EBF139D",
                        column: x => x.SuplierId,
                        principalTable: "SUPLIERS",
                        principalColumn: "SuplierId");
                });

            migrationBuilder.CreateTable(
                name: "INVENTORY",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__INVENTOR__F5FDE6B38CB3E2D9", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK__INVENTORY__Produ__656C112C",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "SALEDETAILS",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitaryPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SALEDETA__135C316D5FF9200A", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK__SALEDETAI__Produ__4CA06362",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK__SALEDETAI__SaleI__4BAC3F29",
                        column: x => x.SaleId,
                        principalTable: "SALES",
                        principalColumn: "SaleId");
                });

            migrationBuilder.CreateTable(
                name: "PURCHASEDETAILS",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PURCHASE__135C316D22F8D778", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK__PURCHASED__Produ__619B8048",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK__PURCHASED__Purch__628FA481",
                        column: x => x.PurchaseId,
                        principalTable: "PURCHASES",
                        principalColumn: "PurchaseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_ProductId",
                table: "INVENTORY",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CategoryId",
                table: "PRODUCTS",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASEDETAILS_ProductId",
                table: "PURCHASEDETAILS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASEDETAILS_PurchaseId",
                table: "PURCHASEDETAILS",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PURCHASES_SuplierId",
                table: "PURCHASES",
                column: "SuplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SALEDETAILS_ProductId",
                table: "SALEDETAILS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SALEDETAILS_SaleId",
                table: "SALEDETAILS",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SALES_PaymentMethodId",
                table: "SALES",
                column: "PaymentMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INVENTORY");

            migrationBuilder.DropTable(
                name: "PURCHASEDETAILS");

            migrationBuilder.DropTable(
                name: "SALEDETAILS");

            migrationBuilder.DropTable(
                name: "PURCHASES");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "SALES");

            migrationBuilder.DropTable(
                name: "SUPLIERS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "PAYMENTMETHODS");
        }
    }
}
