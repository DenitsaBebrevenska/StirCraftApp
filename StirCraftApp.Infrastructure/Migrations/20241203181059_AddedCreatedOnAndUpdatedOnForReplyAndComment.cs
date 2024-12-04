using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreatedOnAndUpdatedOnForReplyAndComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Replies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Replies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d256909c-0b9f-41b4-a606-2851ea5cb140", "AQAAAAIAAYagAAAAEB1AGXM3xikSMWNC1Z93GhMkL1cU15DJu0PDT1HyXpkMEys367w3sAgR1kRPwJKHIQ==", "9ff8c78e-d631-4121-b39b-402981821e9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "821f0ae2-62ca-4b3f-9aab-88fa8a115a7f", "AQAAAAIAAYagAAAAEN7MqK/bBUrXAKN9tOFhb4BLSzQLLxWm36P1T/JrqNTbKMLv+7+nGehVmKa77u2oYw==", "929f5b2b-2f6d-4733-93c7-73e4a1ef4a7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e57c424-9350-4b81-bc3b-94942f9ebe6b", "AQAAAAIAAYagAAAAEDV6V1cYsRmTTZz47IPkRVLQdwNyeWwIqJrw3kATdZdrOu/sqI75dJfPRmNQpYMRzg==", "c9e788e9-9576-4ec4-b320-69211d1ab06f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73262ce9-5e6f-45c5-8ebf-243dc715a0bb", "AQAAAAIAAYagAAAAEPqnSK3BVAUUWLDRiLcLkDmNIP1atHo0cfkmq7Lz2ama656wzovrP3FynxTbflhwXg==", "40114093-89eb-4a6f-b48c-0d922377cbe8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "daa285e6-a66f-4161-870f-0dd3b9738221", "AQAAAAIAAYagAAAAEL0SG2B7AQlQgdLK8ZX+UsbFhASQA93O0Qt+0DOFqe3BU8MmB+NJmlWlbo9+VDXqDw==", "e029340f-a919-40f9-9051-ba17d1de63f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca768cdc-2315-48b6-8ab1-ea5a3b2d252b", "AQAAAAIAAYagAAAAEOx714plj9VxMCwPfbK/b6Sx0pPU1ZJfhKb/4Nk1q0uBGHTiPoLmx5T74KZ85GNMIA==", "a97ba6e3-d948-4861-af7f-16efcc3f438b" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe3c83a9-bafc-42ba-be3f-6651a463e1a3", "AQAAAAIAAYagAAAAEGDYTZi+n8LMwfa5JVzhL2mS03v8KAdpK/oi37KS1z5QTBfM722tBKfXY733IEvokQ==", "2cbfc130-01cd-44a1-b64d-c6eaf06bbb88" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55a8732b-5723-4d35-ba1d-66e2393459a5", "AQAAAAIAAYagAAAAEBMEoIz9MU41/6TalEtU+7WbYVv0ZLj67osiY6P06IFfb06oybfsfkp2vosKSU443A==", "0c1e9f2a-5817-465d-9543-c12df0a3a67e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a1f5390-65c2-4a80-bb66-0028049f6cb1", "AQAAAAIAAYagAAAAEO6uj6UnICieDMdNfxZZK+hMjbszcqoFSQ0Jpf4RSwjjOP8rEwFRlcdYfQhZsfTiPQ==", "10e35705-db1e-4710-a096-f4f4fb06ed59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b6333cc-d9b6-4619-a950-d7c5bb89969d", "AQAAAAIAAYagAAAAELqEvyKDMv/ZOVJuh+N67OharS1OPKk5C8ejjkI1QI59sy68JyWHif5Hn0OlHkE07Q==", "e11a20f0-1718-4714-a0f0-15f80229c42c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8242cae-d157-45ad-80d3-115ffc875ab3", "AQAAAAIAAYagAAAAEIEZzzxv4HIB1KF8ZXZpCoXTKuBlVgf5C+2UnUQUAm8Z+XAS3izPi7dFkhj+0sTmRQ==", "a4b63d26-cc52-4c18-bb3d-74fa19eb621d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d92c5f0-0f68-4e2b-9542-a5144cd14319", "AQAAAAIAAYagAAAAEA1tXIxdK6jxCka5t9eoMgbkUGAsQtyxhcQK3OvqL+wkvtdZdnM79Iw4PkUOHna3OQ==", "f71ef3a0-7dba-4e25-8baa-a8f9b22cfdc4" });
        }
    }
}
