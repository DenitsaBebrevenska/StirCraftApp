using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovingSuggestedIngredientAndAddingFlagToIngredientEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuggestedIngredients");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdminApproved",
                table: "Ingredients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "374ec5bc-076e-4e32-ba33-34d018bcb538", "AQAAAAIAAYagAAAAELaTber0dcPqmwUrdPHVPaQkEVoqmRCK1Ca8YzKOyfo22vgGlXTFfCLt0kj6fbU3AQ==", "9d9aafda-138d-4cc6-af2b-82713fab5dbf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaa5d6a3-27d4-4c5f-9d81-62645d9b183a", "AQAAAAIAAYagAAAAEE9JZRsheOPobztcqGMOloPl/MPd2s+vCM8Y6oqifvuyJW2Dvf64THc8sjMB5zGCVg==", "5e5d057c-2b59-474e-9e5a-7ef7e644cbe2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3acf0899-adf0-4327-9260-54ea285cd56e", "AQAAAAIAAYagAAAAEMz7rgxgYOdL3aXFtnVEHoqP2JMIU20aY9aigYBaXnUS0bf2l/cuF0sSyCtVooEayw==", "3d1d8a34-b38a-4f4c-b1a9-079c7193f2f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5387e17b-1d73-4397-8bc8-63f09066b4a0", "AQAAAAIAAYagAAAAEOENAv4c/Z5XED4SytlGBtzcY6wjf+hNwxZQqA459EkhjpedwoYIM6SlvAY2HxE3Dg==", "ba2663fd-f867-433b-b273-06a018fde2cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b6da351-4c35-4cdc-b1e1-5ce6bf7c0ca6", "AQAAAAIAAYagAAAAEBbg1mE+SVoksD7Pczm7ah781pjPckKFR6y2f+axhFqqgs9jJkBkapyZ2iYQyi+ICg==", "947580b0-f2ed-4f70-9892-2c109facb7f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b6d00cb-b731-47d5-9c57-870ed8fbc0ce", "AQAAAAIAAYagAAAAEGDljjA43OILJV1euwFyojKHWUSNIvXK+Rhg3243tpCQ+AtZKnvfS8LTh0ZgpUMfwA==", "d1ed1a42-2a60-4dfc-b653-8dbc210bd337" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 17,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 18,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 19,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 20,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 21,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 22,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 23,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 24,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 25,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 26,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 27,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 28,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 29,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 30,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 31,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 32,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 33,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 34,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 35,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 36,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 37,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 38,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 39,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 40,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 41,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 42,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 43,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 44,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 45,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 46,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 47,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 48,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 49,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 50,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 51,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 52,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 53,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 54,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 55,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 56,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 57,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 58,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 59,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 60,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 61,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 62,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 63,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 64,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 65,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 66,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 67,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 68,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 69,
                column: "IsAdminApproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 70,
                column: "IsAdminApproved",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdminApproved",
                table: "Ingredients");

            migrationBuilder.CreateTable(
                name: "SuggestedIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAdminReviewed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestedIngredients", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "108a2715-87e5-44c1-b095-eda439dc5ae6", "AQAAAAIAAYagAAAAEMEi8ZrsKC7KBn5rTj1mLL1afF9jwK1ums0bjmV4wBrl4YGup4IbXzIzqPL3uRlFUg==", "7da070e8-cd9e-439a-b1e3-e7163b2db08a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d306c4d3-c7be-4c03-bd72-09463a6ba561", "AQAAAAIAAYagAAAAEEmv8HWaUkIkHzYyqK20krk55bQ3kZrwrINwPbSjV6U2iZ8xf2pdgqDppPdPAGObtw==", "27e70f9a-a481-40e6-a661-c01f576ad1b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67d71b2a-1c3f-405b-8319-4f4fd912211e", "AQAAAAIAAYagAAAAEHsZmI7mY1ACSg0lSyx5+KxGv2UggBTM+6Ouu6/eLag6Zo0Ytc859jHtOG56xrgoAw==", "08608364-c55b-4627-bcf8-3fd883efb3bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16950772-216f-4a2c-98a1-660d91b3e06f", "AQAAAAIAAYagAAAAENzWgDeqxnfydXS323ziU85n3r1mG1ReAfOakrynXQPIlXZqmFyvg/bQwQ2fPF/AMA==", "9d60c8d2-5fb9-4e94-a03c-1351bb1cb66b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2447a9ad-b8e8-4082-b225-558865abe22e", "AQAAAAIAAYagAAAAEBmtYsmTGoLnAomVqEdQz4VyjQDY0OtZoDx1NrxKJbymR8sbG8tWkxv7nyxDlUIY4w==", "b7492d37-4489-43c0-88fb-378fc84be712" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9202e479-0f27-42ad-8431-e7046392183f", "AQAAAAIAAYagAAAAEA3T95M2eoeao+TaDZltHVcryei3SLiNMiElU2wkODpHk2FWy0vnHybSuojDyWdGew==", "45e284b9-76fc-42ba-ac4f-0938064d8de2" });

            migrationBuilder.CreateIndex(
                name: "IX_SuggestedIngredients_IsDeleted",
                table: "SuggestedIngredients",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");
        }
    }
}
