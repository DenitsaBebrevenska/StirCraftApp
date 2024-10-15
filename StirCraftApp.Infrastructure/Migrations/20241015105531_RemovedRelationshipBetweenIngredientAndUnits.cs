using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRelationshipBetweenIngredientAndUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientMeasurementUnit");

            migrationBuilder.AddColumn<bool>(
                name: "IsLiquidSpecific",
                table: "MeasurementUnits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSolid",
                table: "Ingredients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLiquidSpecific",
                table: "MeasurementUnits");

            migrationBuilder.DropColumn(
                name: "IsSolid",
                table: "Ingredients");

            migrationBuilder.CreateTable(
                name: "IngredientMeasurementUnit",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMeasurementUnit", x => new { x.IngredientsId, x.MeasurementUnitsId });
                    table.ForeignKey(
                        name: "FK_IngredientMeasurementUnit_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IngredientMeasurementUnit_MeasurementUnits_MeasurementUnitsId",
                        column: x => x.MeasurementUnitsId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMeasurementUnit_MeasurementUnitsId",
                table: "IngredientMeasurementUnit",
                column: "MeasurementUnitsId");
        }
    }
}
