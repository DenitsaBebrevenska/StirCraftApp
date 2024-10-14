using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnsIngredientsAndUnitsRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBePlural",
                table: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "NameInPlural",
                table: "Ingredients",
                type: "nvarchar(104)",
                maxLength: 104,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IngredientMeasurementUnit",
                columns: table => new
                {
                    IngredientsThatCanHaveThatUnitId = table.Column<int>(type: "int", nullable: false),
                    PossibleMeasurementUnitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMeasurementUnit", x => new { x.IngredientsThatCanHaveThatUnitId, x.PossibleMeasurementUnitsId });
                    table.ForeignKey(
                        name: "FK_IngredientMeasurementUnit_Ingredients_IngredientsThatCanHaveThatUnitId",
                        column: x => x.IngredientsThatCanHaveThatUnitId,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IngredientMeasurementUnit_MeasurementUnits_PossibleMeasurementUnitsId",
                        column: x => x.PossibleMeasurementUnitsId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMeasurementUnit_PossibleMeasurementUnitsId",
                table: "IngredientMeasurementUnit",
                column: "PossibleMeasurementUnitsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientMeasurementUnit");

            migrationBuilder.DropColumn(
                name: "NameInPlural",
                table: "Ingredients");

            migrationBuilder.AddColumn<bool>(
                name: "CanBePlural",
                table: "Ingredients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
