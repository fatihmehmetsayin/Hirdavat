using Microsoft.EntityFrameworkCore.Migrations;

namespace Hirdavat.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Stok = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    InnerBarCode = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Mekanik El Aletleri" },
                    { 2, false, "Elektikli El Aletleri" },
                    { 3, false, "Akülü El Aletleri" },
                    { 4, false, "Havalı El Aletleri" },
                    { 5, false, "Ölçüm Cihazları" },
                    { 6, false, "Bahçe Makinaleri " },
                    { 7, false, "Hobi Aletleri " }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InnerBarCode", "IsDeleted", "Name", "Price", "Stok" },
                values: new object[,]
                {
                    { 1, 1, null, false, "İzeltaş 10 lu", 12.50m, 100 },
                    { 2, 1, null, false, " izeltaş dokuzlu", 40.50m, 200 },
                    { 3, 1, null, false, " stanley uzun", 500m, 300 },
                    { 4, 1, null, false, "Stanley somun ", 12.50m, 100 },
                    { 5, 1, null, false, " Stanley Lokma", 12.50m, 100 },
                    { 6, 1, null, false, "Astor Pvc Boru 65 mm", 12.50m, 100 },
                    { 7, 1, null, false, " Astor Pvc Boru 75 mm", 12.50m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
