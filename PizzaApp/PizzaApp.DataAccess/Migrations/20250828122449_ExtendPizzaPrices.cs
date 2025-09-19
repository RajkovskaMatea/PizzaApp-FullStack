using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ExtendPizzaPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Pizzas",
                newName: "PriceSmall");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceLarge",
                table: "Pizzas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceMedium",
                table: "Pizzas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceLarge",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "PriceMedium",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "PriceSmall",
                table: "Pizzas",
                newName: "Price");
        }
    }
}
