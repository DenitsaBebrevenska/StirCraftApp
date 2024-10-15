using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAnotherFlagToUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSolidSpecific",
                table: "MeasurementUnits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSolidSpecific",
                table: "MeasurementUnits");
        }
    }
}
