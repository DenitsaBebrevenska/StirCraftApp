using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovingQueryFilterForAdminApprovalOnRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recipes_IsAdminApproved",
                table: "Recipes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "013a6763-f55e-4d3d-b0b7-8aedb437c544", "AQAAAAIAAYagAAAAEPcOPaUkWrBeuA7ssjOvuDlS7dfUGKmJMFuMxR4RWuBMOeltj3yxohNa1D0Bv9FANA==", "d456e52a-646e-4e09-8dd4-8021dede35a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ba3785a-5668-4c02-8bd6-baac1d4ddf05", "AQAAAAIAAYagAAAAENplUmhrDwt7RWbOmQ6FHrxE0l0T1AKWhafCakQJzAozrF6P23/T5qtlYngqmqyPeg==", "4c2cacf6-77f6-4672-83a3-863656d3b5a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdcab9f9-cfd1-4464-a8da-88382b566418", "AQAAAAIAAYagAAAAEKiaMMvefHPwm0nKEMG26E4iy/jm7Z9JxfbLBlDpG/J+JtL/YOH+/IwWEn3GJwUYeA==", "285aba75-6e18-4ab4-af76-03a0b640b8c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6880bbab-ada0-45e3-bfee-05f2d35382af", "AQAAAAIAAYagAAAAEDqJiiJbN3RtFXElar0rZIyrJXp/8sJ7EYHDXSQJ1UOc1rpXM3bM37PI5hnZxlzwsg==", "b3b092b5-def2-4b3f-8c0d-c574c5b113b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd83c69a-e0b1-4671-9242-d10e72ab25b8", "AQAAAAIAAYagAAAAEKUBx7oPWbwk2t5sd27TkZIETjcN4Omrux/ByuSMW7gge8egqiWzRqeoKDATKfZfdA==", "b52a85da-f38b-4b66-a670-aba8d224447c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d260a52f-3d48-46f2-acfb-fa992b814a1f", "AQAAAAIAAYagAAAAEL1XFylDCmpLiw9K0gPl8iR4b8thsogmZyaMwTo3gnHJ0cvd9f5BUWf/78OfGQ2Ogg==", "4d55e52f-c769-43e8-98d1-475cae2dd492" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "791adf08-bd45-4ccd-ae64-3619a150d0da", "AQAAAAIAAYagAAAAEKjDP2LfY5OtOnB83/Oe6KcqRMROsqXuqb/qPtL6RyE0lij8TOHjCKa2XftHiKe4vA==", "1f5dd323-7d25-474e-a338-555ac613765f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04ccb71c-7291-4622-93f6-b5bb66623f46", "AQAAAAIAAYagAAAAEOLMRbtay8OMxILWybljLcSI+COxg/TPgHxiLc8LnmMNSsfhg6a8ZqOx2x62Y9N/kw==", "94796402-c736-4739-bb16-b1c632023233" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09982d4b-b3e9-440f-9b8e-57637eb1e841", "AQAAAAIAAYagAAAAEMRitCxCZOAnc8EZmViJB40cAE0LwrXug6p7CTwhEBfpkjoHTBT2VhR3sjKHE5vCeg==", "cc1004cf-412c-44a9-98bb-59e0ade55cef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2ab2dd0-7fe8-4591-9616-293f08ae6441", "AQAAAAIAAYagAAAAEDvMBsZdkreoyQmtNdWKyLFJm0H1zStyRSJlepYke+wGNSm789qPn34X2QJiF+LpbA==", "1fe81c22-ea32-49c9-9103-c256565b946d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e44c8e3-ba47-4453-b85e-f9133f86934a", "AQAAAAIAAYagAAAAENyhHunEfKQYbXUp5ml1DzeVVZLfqQERfmIe3NM+O23d7f2CvomPq6MX33fBLAPGnA==", "a46441d6-1915-4202-9c85-fd2b956cc22f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc29ed1d-8dd0-4ffc-a937-c5cef7ba329e", "AQAAAAIAAYagAAAAEBWzOQUV7WsZIfe0WKMlhNPr/reps+u7Gy9JsPza9C6X2i8nLM9R6h8Wj67t4XxjsQ==", "4beef286-c70a-43c6-a14e-e4a4827e7a65" });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IsAdminApproved",
                table: "Recipes",
                column: "IsAdminApproved",
                filter: "[IsAdminApproved] = 1");
        }
    }
}
