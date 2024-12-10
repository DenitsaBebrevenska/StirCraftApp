using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SwappingUintsForInts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "RecipeIngredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RankingPoints",
                table: "Cooks",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "RequiredPoints",
                table: "CookingRanks",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10bec544-3343-4976-a237-642244b7b0ad", "AQAAAAIAAYagAAAAEBQ8qIsJZsz0hkj3nHsfj5S080+bZ7LjTFfCe+K+x13FjtsbwKB5F269FUR7COD76w==", "e2e5bb02-b7aa-4b8b-b059-e0aaf4355f8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47a0ce60-cddb-45b3-9022-2d088366ec42", "AQAAAAIAAYagAAAAEOV31qZu4IyVjdUFEVH2Ce3x1r8I8y1uPNiR/rdvML4bXMKY+JhJN1QIvYbY9zCLyQ==", "b2bfd186-b8dd-4e27-831f-608825d99320" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "578f0611-49fa-4fb1-bf89-19a5f25bc54b", "AQAAAAIAAYagAAAAEJJmEF8SlUX2qAxrwQTWIICVw7zXTFbL0lZIYRkGd334b81iLh+CIZYeg4qJhUSe8g==", "34ce5b15-e049-45d9-9701-56f4fdf8faae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e276abd-1218-49eb-a7b4-e1233ed1ae67", "AQAAAAIAAYagAAAAEIog5ne5AEbP1KKMYSoGMjWA19ur+fTjodzF/8vXYfPA5+dhBOKoCwbpsH1AHUfkkg==", "16165d77-cae1-414c-a810-c6664300b316" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "421152d1-190d-4c91-9fad-b682e9838b65", "AQAAAAIAAYagAAAAEPZ8VXO1LnBaL7xYxvaiwumWQH8QUJzxBhQuf5jxAiGXR8daSuQS08KyotDhwVSN+A==", "568fe901-bf72-4007-ad4d-b2f0a618435e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6472181c-1436-4113-8327-17e2938b6e3a", "AQAAAAIAAYagAAAAEDq00dHveoR4LZLmYdLaNEf5fDB2gw52kBkTYnE9j+9ICCw52TIpJA9jGQcF1ZQZdA==", "8e73f9a8-2d1b-4277-a186-33439b28a122" });

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequiredPoints",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 2,
                column: "RequiredPoints",
                value: 500);

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 3,
                column: "RequiredPoints",
                value: 1000);

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 4,
                column: "RequiredPoints",
                value: 1500);

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 5,
                column: "RequiredPoints",
                value: 2000);

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 6,
                column: "RequiredPoints",
                value: 3000);

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 7,
                column: "RequiredPoints",
                value: 5000);

            migrationBuilder.UpdateData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 1,
                column: "RankingPoints",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 2,
                column: "RankingPoints",
                value: 1200);

            migrationBuilder.UpdateData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 3,
                column: "RankingPoints",
                value: 2200);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 500);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 7,
                column: "Quantity",
                value: 250);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 8,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 13,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 14,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 15,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 16,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 17,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 18,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 19,
                column: "Quantity",
                value: 200);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 20,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 21,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 22,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 23,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 24,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 25,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 26,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 27,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 28,
                column: "Quantity",
                value: 500);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 29,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 30,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 31,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 32,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 33,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 34,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 35,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 36,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 37,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 38,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 39,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 40,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 41,
                column: "Quantity",
                value: 200);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 42,
                column: "Quantity",
                value: 300);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 43,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 44,
                column: "Quantity",
                value: 250);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 45,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 46,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 47,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 48,
                column: "Quantity",
                value: 100);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 49,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 50,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 51,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 52,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 53,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 54,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 55,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 56,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 57,
                column: "Quantity",
                value: 80);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 58,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 59,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 60,
                column: "Quantity",
                value: 150);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 61,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 62,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 63,
                column: "Quantity",
                value: 200);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 64,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 65,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 66,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 67,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 68,
                column: "Quantity",
                value: 100);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 69,
                column: "Quantity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 70,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 71,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 72,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 73,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 74,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 75,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 76,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 77,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 78,
                column: "Quantity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 79,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 80,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 81,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 82,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 83,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 84,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 85,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 86,
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 87,
                column: "Quantity",
                value: 100);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 88,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 89,
                column: "Quantity",
                value: 100);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 90,
                column: "Quantity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 91,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 92,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 93,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 94,
                column: "Quantity",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Quantity",
                table: "RecipeIngredients",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RankingPoints",
                table: "Cooks",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "RequiredPoints",
                table: "CookingRanks",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dadea3e4-3e39-4ea5-9766-2ce3393d7021", "AQAAAAIAAYagAAAAENAtisk7EF/PZP9RTKnU8brLb/VSvE7WuattuTjJxF4x0Lf4UjnA//R6zMFIgYf9NA==", "6b68298e-9425-413a-9227-3124a236f929" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b70c7e4-cd0f-4945-b8a9-ac78b50af2d7", "AQAAAAIAAYagAAAAEDO13MQXBIzzG3nCZA/xnt7EhaQceXjoq8Rc6LxzNAXuwekxZLVR3vc7G4XYuSLAnA==", "048ccd6a-7532-4106-934c-a2131796683b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "808c8c32-1d16-4da1-bb84-1a6e8212f66e", "AQAAAAIAAYagAAAAEJTPWWkkcSRxAAYWR3bqSBJ5+qZR69K4z50yaYuLGdlNy1Kn0OZ/57MItzfNHh+w2Q==", "f9e2a94e-f09d-4b91-a402-940a98d0463c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71881705-3d86-441e-8a26-28111c51a0d1", "AQAAAAIAAYagAAAAELvpu+/1JWXARtjL/2fzUZ4dXKrWO4OY13w+V87h+6TIFAeF2DNgA6TCjuSWAsIf8w==", "aaae6515-b9c3-4653-ab0e-111c6160bc6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cf71b2b-d6ff-426a-a613-de3132c4980b", "AQAAAAIAAYagAAAAEHaRqa/hXIyWUoB8yffIY6BVBGoax3QbXo0U8PjloYPtTe2FVLKVCfgJZpc/ckKZ0Q==", "5145dc2f-86cd-4f7f-97e5-5b3d6dc35c42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26505f68-681b-4240-ac85-674616f45c67", "AQAAAAIAAYagAAAAEJA94plcjq1M3UO/WuhvYkXUnIBiUWYZI4NfDLX9fdkAx6OyYnd8CPP6oPKvwgeSeQ==", "1d8518e4-bc1a-4eab-a2f2-d2096225a8c5" });

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequiredPoints",
                value: 0L);

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 2,
                column: "RequiredPoints",
                value: 500L);

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 3,
                column: "RequiredPoints",
                value: 1000L);

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 4,
                column: "RequiredPoints",
                value: 1500L);

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 5,
                column: "RequiredPoints",
                value: 2000L);

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 6,
                column: "RequiredPoints",
                value: 3000L);

            migrationBuilder.UpdateData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 7,
                column: "RequiredPoints",
                value: 5000L);

            migrationBuilder.UpdateData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 1,
                column: "RankingPoints",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 2,
                column: "RankingPoints",
                value: 1200L);

            migrationBuilder.UpdateData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 3,
                column: "RankingPoints",
                value: 2200L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 500L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantity",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 6,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 7,
                column: "Quantity",
                value: 250L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 8,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 9,
                column: "Quantity",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 10,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 11,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 12,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 13,
                column: "Quantity",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 14,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 15,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 16,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 17,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 18,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 19,
                column: "Quantity",
                value: 200L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 20,
                column: "Quantity",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 21,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 22,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 23,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 24,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 25,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 26,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 27,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 28,
                column: "Quantity",
                value: 500L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 29,
                column: "Quantity",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 30,
                column: "Quantity",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 31,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 32,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 33,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 34,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 35,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 36,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 37,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 38,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 39,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 40,
                column: "Quantity",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 41,
                column: "Quantity",
                value: 200L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 42,
                column: "Quantity",
                value: 300L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 43,
                column: "Quantity",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 44,
                column: "Quantity",
                value: 250L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 45,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 46,
                column: "Quantity",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 47,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 48,
                column: "Quantity",
                value: 100L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 49,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 50,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 51,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 52,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 53,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 54,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 55,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 56,
                column: "Quantity",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 57,
                column: "Quantity",
                value: 80L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 58,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 59,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 60,
                column: "Quantity",
                value: 150L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 61,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 62,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 63,
                column: "Quantity",
                value: 200L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 64,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 65,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 66,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 67,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 68,
                column: "Quantity",
                value: 100L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 69,
                column: "Quantity",
                value: 50L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 70,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 71,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 72,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 73,
                column: "Quantity",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 74,
                column: "Quantity",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 75,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 76,
                column: "Quantity",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 77,
                column: "Quantity",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 78,
                column: "Quantity",
                value: 6L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 79,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 80,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 81,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 82,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 83,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 84,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 85,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 86,
                column: "Quantity",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 87,
                column: "Quantity",
                value: 100L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 88,
                column: "Quantity",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 89,
                column: "Quantity",
                value: 100L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 90,
                column: "Quantity",
                value: 12L);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 91,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 92,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 93,
                column: "Quantity",
                value: null);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 94,
                column: "Quantity",
                value: 1L);
        }
    }
}
