using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f89760b-50a8-478d-b44a-f711a4d6abe6", null, "User", "USER" });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9f89760b-50a8-478d-b44a-f711a4d6abe6", "3b3c303f-b227-48d8-a30d-1932e90b058a" },
                    { "9f89760b-50a8-478d-b44a-f711a4d6abe6", "edc8a753-f0dc-483f-bbaf-d26dc2827d54" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f89760b-50a8-478d-b44a-f711a4d6abe6", "3b3c303f-b227-48d8-a30d-1932e90b058a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9f89760b-50a8-478d-b44a-f711a4d6abe6", "edc8a753-f0dc-483f-bbaf-d26dc2827d54" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f89760b-50a8-478d-b44a-f711a4d6abe6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e70d7666-bafa-4dcd-b972-818c028f371d", "AQAAAAIAAYagAAAAEPpQdeJHZRbQBuPVBnm/fKCVPXUbQ3zl2FQgfATOjY9rmzvgg0VSlaVQf5Z8EZBGDw==", "1584aeb8-043d-4b58-8dd3-41cd25ffa7d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39ced363-9143-4e47-b8b5-5fcce017ae42", "AQAAAAIAAYagAAAAEKBtM+9fApCKw+pUkmCPxJOgbp0RidthzXbqSWa0W7uaxb+nxJRGNBayulAGelhnMA==", "871fa3ec-bf87-4d66-842a-745a0a471bbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "344677f9-cf53-4552-842c-3fc9f857cf18", "AQAAAAIAAYagAAAAEInQygfdy0Lpnzr48FstlHfzqNyEPZ6UcFVfRy+ZJ00v6p9MDl0BP/O+rBiSfuvM6w==", "fc97e10e-6cad-49b4-81ee-cfa6aa752b03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5a322fb-d0f2-4e6c-bc5b-525bc781f23b", "AQAAAAIAAYagAAAAEE4WLUMxx48S/oDtBQaoWeLgofdnGgpx6/x4AOGQLwgKpntkG648l8H3gAfHWZ2RNQ==", "66c6bdea-e1b8-45d8-a4d3-e98c8c1b8284" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fee3d4e6-ad44-4cb5-8f1c-74a287c89586", "AQAAAAIAAYagAAAAEPfw/4ey0uc3pau+3lkz+YbaJOPpGnu8zQmJPjN8FA6UZxNFh+S1ol0fV1IAtlhMew==", "92e37f2a-d762-401d-ac72-1d2ffcbde9a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a326e2c4-5b09-4dd0-abf4-bdc24a1ebea9", "AQAAAAIAAYagAAAAEAMaddOGTgu772A0HtUrDAJLckYnfirbCxwhSYHyWor+UKSqDSpmQdt1S+tQPZBpSw==", "6f1e0697-06aa-4a7a-bfb7-5f21ae833620" });
        }
    }
}
