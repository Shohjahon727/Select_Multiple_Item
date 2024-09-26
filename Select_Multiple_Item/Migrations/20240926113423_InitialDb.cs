using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Select_Multiple_Item.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Manufacturer = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Manufacturer", "Model", "Price" },
                values: new object[,]
                {
                    { 1, 0, 0, "Cobalt", 10000m },
                    { 2, 0, 0, "Malibu", 15000m },
                    { 3, 1, 8, "Camry", 12000m },
                    { 4, 5, 4, "Civic", 10000m },
                    { 5, 3, 6, "Focus", 13000m },
                    { 6, 0, 2, "X5", 35000m },
                    { 7, 4, 1, "A4", 30000m },
                    { 8, 2, 3, "C-Class", 20000m },
                    { 9, 2, 7, "Elantra", 25000m },
                    { 10, 1, 5, "Optima", 15000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
