using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sample_rest_api.Migrations
{
    public partial class AddCategoryRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Productos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoryId",
                table: "Productos",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categories_CategoryId",
                table: "Productos",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categories_CategoryId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CategoryId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Productos");
        }
    }
}
