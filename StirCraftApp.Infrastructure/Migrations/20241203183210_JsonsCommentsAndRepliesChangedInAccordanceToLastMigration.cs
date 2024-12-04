using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JsonsCommentsAndRepliesChangedInAccordanceToLastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "359d8319-617a-49a1-aca4-298aa46e6463", "AQAAAAIAAYagAAAAEKWs4UtYJVHXoI34HdpFpOgCtHd9Xh3WOY+DnZ+DhK47QfpsAStezbWS5AvwXE7cTQ==", "54f51482-a214-4e86-8bb0-53243cc5366a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55585f6a-692d-4638-a5c4-3a064dd25043", "AQAAAAIAAYagAAAAELGUpdrqWW0o91arUewIaYw/TgqwOfn8kDQoU8d3PSGMgHkxxZU2tc8kxHzFcj3PVQ==", "bb316e15-9f8d-4b7e-9bfb-83d6019acc54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8bb6da2-2eba-4e28-8388-0d653edd97e1", "AQAAAAIAAYagAAAAEIE0NMCELayMYKhpbd9nXOSnJdd8tUs1OdGgmvhFpJIlAhOvQCLpi92rVSdxpAq0lA==", "5cd398bb-e722-490c-8bc7-6817d8bf4d8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc7463b2-4778-4a38-b524-6360352d7c8a", "AQAAAAIAAYagAAAAEM79vX9XcRD/vnwNyXFwp57u4zgLNNPw8ZfX808TaRTqcBs+dk3uQczYN7kcI7Rbhg==", "475c57ec-351f-4c27-a319-29aef62cb599" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "178462ed-f5eb-4bbb-89bb-5563cbf41b49", "AQAAAAIAAYagAAAAEGfg0Dm9asXYQJlnZz7JKtTwmVKKqZNF3tleUVFkv0HCL+RucbP6zfDZqGQUJU4AHA==", "fdcaa993-f6c6-4b10-b530-55d8a8e3b9a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4f57e43-eb8a-4e5b-b741-511126fc9f77", "AQAAAAIAAYagAAAAEJe6WNtersc0qTQwDRM2qsYiJ1uERHOllKdhm/faQVh8GrgcVHYDYdggdLBJfz7dkw==", "7ab88609-cbf5-4615-9caa-f48272555a57" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 10, 12, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 10, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 10, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 13, 12, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 30, 12, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 3, 10, 27, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 12, 10, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 3, 1, 27, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 10, 14, 2, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                column: "CreatedOn",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
