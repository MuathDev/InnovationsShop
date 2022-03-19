using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class productType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductBrandId",
                table: "Tbproducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "Tbproducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tbproductsbrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbproductsbrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbproductstype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbproductstype", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbproducts_ProductBrandId",
                table: "Tbproducts",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbproducts_ProductTypeId",
                table: "Tbproducts",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbproducts_Tbproductsbrand_ProductBrandId",
                table: "Tbproducts",
                column: "ProductBrandId",
                principalTable: "Tbproductsbrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbproducts_Tbproductstype_ProductTypeId",
                table: "Tbproducts",
                column: "ProductTypeId",
                principalTable: "Tbproductstype",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbproducts_Tbproductsbrand_ProductBrandId",
                table: "Tbproducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbproducts_Tbproductstype_ProductTypeId",
                table: "Tbproducts");

            migrationBuilder.DropTable(
                name: "Tbproductsbrand");

            migrationBuilder.DropTable(
                name: "Tbproductstype");

            migrationBuilder.DropIndex(
                name: "IX_Tbproducts_ProductBrandId",
                table: "Tbproducts");

            migrationBuilder.DropIndex(
                name: "IX_Tbproducts_ProductTypeId",
                table: "Tbproducts");

            migrationBuilder.DropColumn(
                name: "ProductBrandId",
                table: "Tbproducts");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "Tbproducts");
        }
    }
}
