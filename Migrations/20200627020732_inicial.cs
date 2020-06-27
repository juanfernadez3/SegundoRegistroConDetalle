using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SegundoRegistroConDetalle.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    SuplidorId = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenId);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    SuplidorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.SuplidorId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrdenId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductosId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false),
                    Inventario = table.Column<int>(nullable: false),
                    SuplidorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductosId);
                    table.ForeignKey(
                        name: "FK_Productos_Suplidores_SuplidorId",
                        column: x => x.SuplidorId,
                        principalTable: "Suplidores",
                        principalColumn: "SuplidorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorId", "Nombre" },
                values: new object[] { 1, "JuanSuplidor" });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductosId", "Costo", "Descripcion", "Inventario", "SuplidorId" },
                values: new object[] { 1, 15m, "Mascarillas", 1000, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_OrdenId",
                table: "OrdenesDetalle",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_SuplidorId",
                table: "Productos",
                column: "SuplidorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesDetalle");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Suplidores");
        }
    }
}
