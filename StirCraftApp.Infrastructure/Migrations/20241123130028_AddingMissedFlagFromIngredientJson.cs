using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingMissedFlagFromIngredientJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "524fcd89-0394-4897-ae12-00920a69bda4", "AQAAAAIAAYagAAAAEMz+uMV5SvwE5grHxayNQtm2NcrWkY5Rwps40nYMZSlEUySV3qKO4olVesDrlMjwog==", "9439be68-f28d-4fcd-a59c-43e4cea72456" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8d65fbe-ae1c-4930-a604-41861f42afca", "AQAAAAIAAYagAAAAEHNDBFkbVhYdDmdOycgGByY9C25wAXB6LZrzrK6sGbXaijey3wa0GUjXa4Ru3Mg81Q==", "c76fb87f-9648-452a-9917-6e5a4698994f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c61ddc1-d6f1-4295-a68d-e3c86323df7a", "AQAAAAIAAYagAAAAENzRxjdiV+kwjsa8HowOvPGvu0ivMfp/4WMu5dyjVc5FwHZqhB9IkjcFalIwkzJerA==", "f5763920-d051-4b7a-8b5f-a41d4986c84c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af23a789-e6ee-4523-8fc3-d1ea8496280f", "AQAAAAIAAYagAAAAEK1gXZIXzVEr4XYxeBrALR8n0HoMgpNWrEdh4f9VNZWot9mcXUHQA2adwh/4EdC8vA==", "615e2a2f-e7e3-4aed-ba05-20c96cd86933" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8520e589-8b38-4a69-9327-173c9a4aef77", "AQAAAAIAAYagAAAAEH69xbkWhZKkGRsIAt2Eynu4agT/iw7FAwFYydAQ9g2+zeZL190QGUMLSqgBD1sIOQ==", "1bcd54a9-4789-49e4-9812-6aec7fbcdbe1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da95b578-d8e0-4851-a61b-9269f7ea53fc", "AQAAAAIAAYagAAAAEA5yTzfrTBOgHXqD1X3lK+m82RmZmPVIs+tcsi5GdUTlKh9P6UQ/qLnKq4IbRQMtYw==", "b68a70a5-f799-437e-8967-2f58f2661a98" });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 34,
                column: "IsAdminApproved",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 34,
                column: "IsAdminApproved",
                value: false);
        }
    }
}
