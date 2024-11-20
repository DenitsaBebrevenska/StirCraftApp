using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingSuggestedIngredientEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuggestedIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsAdminReviewed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuggestedIngredients");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5c1e9e8-6ae7-441e-b3c6-9021e37b3634", "AQAAAAIAAYagAAAAEBXTcCFUoNfw3nuNwEpqxdMQW8M+FTlZoA3GyFTnUKeaZycyVRLexLFVpC7tbo9lKA==", "0f70a0d3-63e7-44bd-92e6-4e1e07e2d32e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4ec3db3-bf2c-4ba0-93ea-d19d45af047c", "AQAAAAIAAYagAAAAEMzWEyAtt/DgW4zfisJycnqJoZw0xzgkUGGdnvfN5EKS3JW3AUQTChcZFlW6lu+BNQ==", "4c672ca3-015f-4871-b36a-0cfa60185807" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "323140e9-1e79-486e-a5c7-7bd9fb83eb60", "AQAAAAIAAYagAAAAEFPMv47kI5DpuXkT3AFhOnGJ/Hk6/KreXE/c4Gnrg4UXpD7oct0N2CiMib6VzMeu+g==", "99d007d9-28d8-4f1a-a7a7-e3099a6564fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c23f254a-88af-4e7d-ad79-d12239daafd8", "AQAAAAIAAYagAAAAEOVe0QU9QIPV70QLADru7IwGRQu7f+72ylWTTaujPn20jULQE223AmyqvL6UrBFjWw==", "f6cf8b37-7f10-43f9-bd42-1e01be7957a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b4bdbb0-85a2-47b7-aa0f-b8476566e0d4", "AQAAAAIAAYagAAAAEI5GvnL6CyeuICSISWh/wSOfWNJKW5NqfTBPfuRuRlZTW43Wyfz+ru0Twi4guXb7VQ==", "530ed271-3876-4d66-a44d-bd7680a255b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dc08702-ca06-44ad-bd31-584fb4b0fc35", "AQAAAAIAAYagAAAAEPztByBtQUCTw30ma+FafLK1DD+ZkYFQHFYKt7weQUIfhUVQl6wQm9wVBpV66yH2QQ==", "58ba1580-33ce-4104-bce0-a058919ef777" });
        }
    }
}
