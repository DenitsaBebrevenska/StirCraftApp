using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CookingRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RequiredPoints = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsAllergen = table.Column<bool>(type: "bit", nullable: false),
                    IsAdminApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RankingPoints = table.Column<long>(type: "bigint", nullable: false),
                    CookingRankId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cooks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cooks_CookingRanks_CookingRankId",
                        column: x => x.CookingRankId,
                        principalTable: "CookingRanks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PreparationSteps = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    CookId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAdminApproved = table.Column<bool>(type: "bit", nullable: false),
                    AdminNotes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Cooks_CookId",
                        column: x => x.CookId,
                        principalTable: "Cooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoriesRecipes",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesRecipes", x => new { x.RecipeId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoriesRecipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoriesRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeImages_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: true),
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: true),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecipeRatings_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersFavoriteRecipes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFavoriteRecipes", x => new { x.UserId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_UsersFavoriteRecipes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersFavoriteRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replies_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c63bad56-e374-4a01-ac1a-f49231cd1e2f", null, "Cook", "COOK" },
                    { "eec0c147-bcdc-49f0-aadc-9b2d906ee763", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "DeletedOnUtc", "DisplayName", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a575c2a-065c-487a-8b56-cfd897b1b5ce", 0, "https://plus.unsplash.com/premium_photo-1661778091956-15dbe6e47442?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "e70d7666-bafa-4dcd-b972-818c028f371d", null, "ThePowerOfMorgoth", "galadriel@example.com", false, false, false, null, "GALADRIEL@EXAMPLE.COM", "GALADRIEL@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPpQdeJHZRbQBuPVBnm/fKCVPXUbQ3zl2FQgfATOjY9rmzvgg0VSlaVQf5Z8EZBGDw==", null, false, "1584aeb8-043d-4b58-8dd3-41cd25ffa7d7", false, "galadriel@example.com" },
                    { "3b3c303f-b227-48d8-a30d-1932e90b058a", 0, "https://plus.unsplash.com/premium_photo-1658506818080-0546c7636830?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "39ced363-9143-4e47-b8b5-5fcce017ae42", null, "LoveLink", "zelda@example.com", false, false, false, null, "ZELDA@EXAMPLE.COM", "ZELDA@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKBtM+9fApCKw+pUkmCPxJOgbp0RidthzXbqSWa0W7uaxb+nxJRGNBayulAGelhnMA==", null, false, "871fa3ec-bf87-4d66-842a-745a0a471bbe", false, "zelda@example.com" },
                    { "6d362fcc-dc94-4385-8b38-844527a2c579", 0, null, "344677f9-cf53-4552-842c-3fc9f857cf18", null, "StirCraftAdmin", "admin@example.com", false, false, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEInQygfdy0Lpnzr48FstlHfzqNyEPZ6UcFVfRy+ZJ00v6p9MDl0BP/O+rBiSfuvM6w==", null, false, "fc97e10e-6cad-49b4-81ee-cfa6aa752b03", false, "admin@example.com" },
                    { "98f61b51-9ae7-4107-a247-29d1c68a7d32", 0, "https://plus.unsplash.com/premium_photo-1673830185832-2d5f30a900ed?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "e5a322fb-d0f2-4e6c-bc5b-525bc781f23b", null, "AdrianTheAdventurer", "adrian@example.com", false, false, false, null, "ADRIAN@EXAMPLE.COM", "ADRIAN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEE4WLUMxx48S/oDtBQaoWeLgofdnGgpx6/x4AOGQLwgKpntkG648l8H3gAfHWZ2RNQ==", null, false, "66c6bdea-e1b8-45d8-a4d3-e98c8c1b8284", false, "adrian@example.com" },
                    { "edc8a753-f0dc-483f-bbaf-d26dc2827d54", 0, "https://plus.unsplash.com/premium_photo-1661768360749-b60196445a6d?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "fee3d4e6-ad44-4cb5-8f1c-74a287c89586", null, "KateMiddleton", "kate@example.com", false, false, false, null, "KATE@EXAMPLE.COM", "KATE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPfw/4ey0uc3pau+3lkz+YbaJOPpGnu8zQmJPjN8FA6UZxNFh+S1ol0fV1IAtlhMew==", null, false, "92e37f2a-d762-401d-ac72-1d2ffcbde9a7", false, "kate@example.com" },
                    { "f44c3f06-172b-491e-b71d-8672ac7595cb", 0, "https://plus.unsplash.com/premium_photo-1677852512190-5a89ee399aed?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "a326e2c4-5b09-4dd0-abf4-bdc24a1ebea9", null, "ChefBob", "bob@example.com", false, false, false, null, "BOB@EXAMPLE.COM", "BOB@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAMaddOGTgu772A0HtUrDAJLckYnfirbCxwhSYHyWor+UKSqDSpmQdt1S+tQPZBpSw==", null, false, "6f1e0697-06aa-4a7a-bfb7-5f21ae833620", false, "bob@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DeletedOnUtc", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Asian Cuisine" },
                    { 2, null, false, "Dessert" },
                    { 3, null, false, "Amuse Bouche" },
                    { 4, null, false, "Italian Cuisine" },
                    { 5, null, false, "Grill & Barbecue" },
                    { 6, null, false, "Salads" },
                    { 7, null, false, "Seafood" },
                    { 8, null, false, "Pasta" },
                    { 9, null, false, "Vegetarian" },
                    { 10, null, false, "Vegan" },
                    { 11, null, false, "Breakfast" },
                    { 12, null, false, "Soups & Stews" },
                    { 13, null, false, "Snacks" },
                    { 14, null, false, "Beverages" },
                    { 15, null, false, "Appetizers" },
                    { 16, null, false, "Comfort Food" },
                    { 17, null, false, "French Cuisine" },
                    { 18, null, false, "Mexican Cuisine" },
                    { 19, null, false, "Mediterranean Cuisine" },
                    { 20, null, false, "Baking & Pastries" },
                    { 21, null, false, "Russian Cuisine" }
                });

            migrationBuilder.InsertData(
                table: "CookingRanks",
                columns: new[] { "Id", "DeletedOnUtc", "IsDeleted", "RequiredPoints", "Title" },
                values: new object[,]
                {
                    { 1, null, false, 0L, "StirCraftNovice" },
                    { 2, null, false, 500L, "StirSpecialist" },
                    { 3, null, false, 1000L, "FlavorOperative" },
                    { 4, null, false, 1500L, "SeasonedCommander" },
                    { 5, null, false, 2000L, "MasterOfStirCraft" },
                    { 6, null, false, 3000L, "CulinaryOverlord" },
                    { 7, null, false, 5000L, "StirCraftGod" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "DeletedOnUtc", "IsAdminApproved", "IsAllergen", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, true, false, false, "flour" },
                    { 2, null, true, true, false, "egg" },
                    { 3, null, true, false, false, "sugar" },
                    { 4, null, true, true, false, "milk" },
                    { 5, null, true, false, false, "salt" },
                    { 6, null, true, true, false, "butter" },
                    { 7, null, true, false, false, "olive oil" },
                    { 8, null, true, false, false, "tomato" },
                    { 9, null, true, false, false, "garlic" },
                    { 10, null, true, false, false, "onion" },
                    { 11, null, true, false, false, "chicken breast" },
                    { 12, null, true, false, false, "ground beef" },
                    { 13, null, true, false, false, "carrot" },
                    { 14, null, true, true, false, "celery" },
                    { 15, null, true, true, false, "almond" },
                    { 16, null, true, true, false, "peanut" },
                    { 17, null, true, true, false, "soy sauce" },
                    { 18, null, true, false, false, "lemon" },
                    { 19, null, true, false, false, "lime" },
                    { 20, null, true, false, false, "basil" },
                    { 21, null, true, false, false, "parsley" },
                    { 22, null, true, false, false, "mushroom" },
                    { 23, null, true, false, false, "spinach" },
                    { 24, null, true, false, false, "coconut milk" },
                    { 25, null, true, true, false, "shrimp" },
                    { 26, null, true, false, false, "salmon" },
                    { 27, null, true, false, false, "tofu" },
                    { 28, null, true, false, false, "chickpeas" },
                    { 29, null, true, false, false, "potato" },
                    { 30, null, true, false, false, "rice" },
                    { 31, null, true, false, false, "pasta" },
                    { 32, null, true, false, false, "broccoli" },
                    { 33, null, true, false, false, "cauliflower" },
                    { 34, null, true, false, false, "green beans" },
                    { 35, null, true, false, false, "zucchini" },
                    { 36, null, true, false, false, "corn" },
                    { 37, null, true, true, false, "cheese" },
                    { 38, null, true, true, false, "cream" },
                    { 39, null, true, true, false, "yogurt" },
                    { 40, null, true, false, false, "honey" },
                    { 41, null, true, false, false, "maple syrup" },
                    { 42, null, true, false, false, "baking powder" },
                    { 43, null, true, false, false, "yeast" },
                    { 44, null, true, false, false, "cinnamon" },
                    { 45, null, true, false, false, "cumin" },
                    { 46, null, true, false, false, "ginger" },
                    { 47, null, true, false, false, "vanilla extract" },
                    { 48, null, true, false, false, "black pepper" },
                    { 49, null, true, false, false, "oregano" },
                    { 50, null, true, false, false, "paprika" },
                    { 51, null, true, true, false, "spaghetti" },
                    { 52, null, true, false, false, "chili flakes" },
                    { 53, null, true, false, false, "chili powder" },
                    { 54, null, true, false, false, "quinoa" },
                    { 55, null, true, false, false, "cucumber" },
                    { 56, null, true, false, false, "cherry tomato" },
                    { 57, null, true, false, false, "red onion" },
                    { 58, null, true, false, false, "avocado" },
                    { 59, null, true, true, false, "tahini" },
                    { 60, null, true, false, false, "cilantro" },
                    { 61, null, true, true, false, "almond flour" },
                    { 62, null, true, true, false, "berries mix" },
                    { 63, null, true, true, false, "taco shell" },
                    { 64, null, true, true, false, "tortilla" },
                    { 65, null, true, true, false, "egg noodles" },
                    { 66, null, true, true, false, "mustard" },
                    { 67, null, true, true, false, "Worcestershire sauce" },
                    { 68, null, true, true, false, "sour cream" },
                    { 69, null, true, false, false, "jalapeño" },
                    { 70, null, true, false, false, "beef" },
                    { 71, null, true, false, false, "banana" },
                    { 72, null, true, true, false, "corn flour" },
                    { 73, null, true, false, false, "coconut flour" },
                    { 74, null, true, true, false, "oats" },
                    { 75, null, true, false, false, "brown sugar" },
                    { 76, null, true, false, false, "powdered sugar" },
                    { 77, null, true, false, false, "vegetable oil" },
                    { 78, null, true, false, false, "canned beans" },
                    { 79, null, true, false, false, "red bean paste" },
                    { 80, null, true, false, false, "lentils" },
                    { 81, null, true, false, false, "rice flour" },
                    { 82, null, true, true, false, "parmesan" },
                    { 83, null, true, false, false, "rice milk" },
                    { 84, null, true, true, false, "almond milk" },
                    { 85, null, true, false, false, "water" },
                    { 86, null, true, false, false, "matcha" },
                    { 87, null, true, false, false, "apple cider vinegar" },
                    { 88, null, true, false, false, "white wine vinegar" },
                    { 89, null, true, false, false, "balsamic vinegar" },
                    { 90, null, true, false, false, "red wine" },
                    { 91, null, true, false, false, "white wine" },
                    { 92, null, true, true, false, "chocolate chips" },
                    { 93, null, true, false, false, "pumpkin" },
                    { 94, null, true, false, false, "nutmeg" },
                    { 95, null, true, false, false, "cornstarch" },
                    { 96, null, true, false, false, "vegetable broth" },
                    { 97, null, true, false, false, "bay leaf" },
                    { 98, null, true, false, false, "green pumpkin seeds" },
                    { 99, null, true, false, false, "rosemary" },
                    { 100, null, true, false, false, "dill" }
                });

            migrationBuilder.InsertData(
                table: "MeasurementUnits",
                columns: new[] { "Id", "Abbreviation", "DeletedOnUtc", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "g", null, false, "Gram" },
                    { 2, "kg", null, false, "Kilogram" },
                    { 3, "mg", null, false, "Milligram" },
                    { 4, "oz", null, false, "Ounce" },
                    { 5, "lb", null, false, "Pound" },
                    { 6, "L", null, false, "Liter" },
                    { 7, "mL", null, false, "Milliliter" },
                    { 8, "tsp", null, false, "Teaspoon" },
                    { 9, "tbsp", null, false, "Tablespoon" },
                    { 10, "cup", null, false, "Cup" },
                    { 11, "fl oz", null, false, "Fluid Ounce" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c63bad56-e374-4a01-ac1a-f49231cd1e2f", "1a575c2a-065c-487a-8b56-cfd897b1b5ce" },
                    { "eec0c147-bcdc-49f0-aadc-9b2d906ee763", "6d362fcc-dc94-4385-8b38-844527a2c579" },
                    { "c63bad56-e374-4a01-ac1a-f49231cd1e2f", "98f61b51-9ae7-4107-a247-29d1c68a7d32" },
                    { "c63bad56-e374-4a01-ac1a-f49231cd1e2f", "f44c3f06-172b-491e-b71d-8672ac7595cb" }
                });

            migrationBuilder.InsertData(
                table: "Cooks",
                columns: new[] { "Id", "About", "CookingRankId", "DeletedOnUtc", "IsDeleted", "RankingPoints", "UserId" },
                values: new object[,]
                {
                    { 1, "I am a home cook with love for classic comfort foods. I often experiment with traditional recipes, adding my personal twist to create something familiar yet unique.", 1, null, false, 10L, "f44c3f06-172b-491e-b71d-8672ac7595cb" },
                    { 2, "Inspired by my travels, I enjoy combining fresh, vibrant ingredients like olive oil, herbs, and seafood to create dishes that are both healthy and full of flavor. My philosophy in cooking revolves around simplicity. I love the Mediterranean Cuisine.", 3, null, false, 1200L, "98f61b51-9ae7-4107-a247-29d1c68a7d32" },
                    { 3, "I am passionate about modern fusion cuisine, blending flavors and techniques from around the world. I think of myself as quite innovative in the use of seasonal ingredients and attention to detail, making every meal an unforgettable experience. Also I excel at Asian cuisine, you can call me Senpai!", 5, null, false, 2200L, "1a575c2a-065c-487a-8b56-cfd897b1b5ce" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "AdminNotes", "CookId", "CreatedOn", "DeletedOnUtc", "DifficultyLevel", "IsAdminApproved", "IsDeleted", "Name", "PreparationSteps", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, 2, new DateTime(2024, 10, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, false, "Spaghetti Aglio e Olio", "Cook the spaghetti in salted boiling water until al dente. Reserve some pasta water before draining. Heat olive oil in a pan over medium heat, then add thinly sliced garlic and chili flakes. Sauté until fragrant but not browned.Add the cooked spaghetti to the pan and toss with the garlic oil. Add reserved pasta water to loosen the sauce if needed. Season with salt and pepper to taste, garnish with fresh parsley, and serve.", new DateTime(2024, 10, 6, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, 2, new DateTime(2024, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, false, "Quinoa Salad", "Cook quinoa in water (you can use vegetable broth if you like). Let it cool. In a large bowl, combine diced cucumber, cherry tomatoes, red onion, and avocado. Add the cooled quinoa and mix well. In a small bowl, whisk together lemon juice, olive oil, tahini, salt, and pepper. Pour the dressing over the salad and toss. Garnish with fresh herbs like parsley and cilantro and serve chilled.", new DateTime(2024, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, 3, new DateTime(2024, 8, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, false, "Gluten-Free Almond Pancakes", "In a bowl, whisk together almond flour, eggs, baking powder, vanilla extract, and a pinch of salt until smooth. Heat a non-stick pan over medium heat and grease lightly with butter. Pour small amounts of batter onto the pan and cook until bubbles form on the surface, then flip and cook the other side until golden brown. Serve pancakes with fresh berries, maple syrup, and a sprinkle of almond slices for garnish.", new DateTime(2024, 8, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, 1, new DateTime(2024, 7, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, false, "Spicy Chicken Tacos", "Marinate chicken breast in a mixture of chili powder, cumin, paprika, garlic, lime juice, and olive oil for at least 30 minutes. Cook the marinated chicken in a pan over medium heat until fully cooked and slightly charred. Warm the taco shells in the oven or on a pan. Assemble the tacos by adding chicken, finely chopped ripe tomatoes, onion, cilantro, jalapeño, and lime, and avocado.", new DateTime(2024, 7, 10, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, 3, new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 3, true, false, "Classic Beef Stroganoff", "Cook egg noodles according to package instructions, drain, and set aside. In a large pan, brown strips of beef in butter over high heat. Remove from the pan and set aside. In the same pan, sauté onions and mushrooms until softened. Add garlic and cook for another minute. Stir in beef broth, mustard, and Worcestershire sauce, then return the beef to the pan. Reduce heat, stir in sour cream, and simmer until the sauce thickens. Serve the beef stroganoff over egg noodles, garnished with fresh parsley.", new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, null, 1, new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, false, "Granny`s Homemade Mayo", "Place oil, egg, lemon juice, Dijon mustard, salt, and pepper in a large bowl.Use a hand-held immersion blender to blend mixture until fully emulsified, taking care not to over-blend. Store in a tightly closed container; refrigerate until using.", new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, null, 3, new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, false, "Banana Bread", "In a mixing bowl, mash the ripe bananas with a fork until completely smooth. Stir the melted butter into the mashed bananas.Mix in the baking soda and salt. Stir in the sugar, beaten egg, and vanilla extract. Mix in the flour.Pour the batter into your prepared loaf pan.Bake for 55 to 65 minutes at 175°C, or until a toothpick or wooden skewer inserted into the center comes out clean. Cool and serve.", new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, null, 2, new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, false, "Mochi", "Wrap red bean paste in aluminum foil and place in the freezer until solid, at least 1 hour.Mix glutinous rice flour and green tea powder thoroughly in a microwave-safe bowl.Stir in water, then sugar; mix until smooth.Cover the bowl with plastic wrap and microwave for 3 minutes 30 seconds.Meanwhile, remove red bean paste from the freezer and divide into 8 equal balls. Set aside.Remove rice flour mixture from the microwave. Stir and heat, covered, for another 15 to 30 seconds.Dust a work surface with cornstarch. Roll about 2 tablespoons of hot rice flour mixture into a ball. Flatten the ball and place one ball of frozen red bean paste in the center. Pinch and press the dough around the bean paste until completely covered.Sprinkle with additional cornstarch and place mochi, seam-side down, in a paper muffin liner to prevent sticking.Enjoy!", new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, null, 1, new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, false, "Choco Chip Cookies", "Preheat oven to 375 degrees F. Line three baking sheets with parchment paper and set aside. In a medium bowl mix flour, baking soda, baking powder and salt. Set aside. Cream together butter and sugars until combined. Beat in eggs and vanilla until light (about 1 minute). Mix in the dry ingredients until combined. Add chocolate chips and mix well. Roll 2-3 Tablespoons (depending on how large you like your cookies) of dough at a time into balls and place them evenly spaced on your prepared cookie sheets. Bake in preheated oven for approximately 8-10 minutes. Take them out when they are just barely starting to turn brown. Let them sit on the baking pan for 5 minutes before removing to cooling rack.", new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, null, 2, new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, false, "Pumpkin Soup", "Preheat oven to 425 degrees Fahrenheit and line a baking sheet with parchment paper for easy cleanup. Carefully halve the pumpkin and scoop out the seeds.Slice each pumpkin halve in half to make quarters. Brush or rub 1 tablespoon olive oil over the flesh of the pumpkin and place the quarters, cut sides down, onto the baking sheet. Roast for 35 minutes or longer, until the orange flesh is easily pierced through with a fork. Set it aside to cool for a few minutes.Heat the remaining 3 tablespoons olive oil in a large Dutch oven or heavy-bottomed pot over medium heat. Once the oil is shimmering, add onion, garlic and salt to the skillet. Stir to combine. Cook, stirring occasionally, until onion is translucent, about 8 to 10 minutes. Peel the pumpkin skin off the pumpkins and discard the skin.Add the pumpkin flesh, cinnamon, nutmeg and ground black pepper. Use your stirring spoon to break up the pumpkin a bit. Pour in the broth. Bring the mixture to a boil, then reduce heat and simmer for about 15 minutes, to give the flavors time to meld. Toast the pumpkin seeds in a medium skillet over medium-low heat, stirring frequently, until fragrant, golden and making little popping noises.Once the pumpkin mixture is done cooking, stir in the coconut milk and maple syrup. Remove the soup from heat and let it cool slightly. You can use an immersion blender to blend this soup in the pot. Securely fasten the blender’s lid and use a kitchen towel to protect your hand from steam escaping from the top of the blender as you purée the mixture until smooth. Transfer the puréed soup to a serving bowl and repeat with the remaining batches.Taste and adjust if necessary.", new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, null, 2, new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, false, "Easy Weeknight Spaghetti", "To a large pan, add the pasta, cover with 3 cups cold water, optional salt to taste, and boil over high heat until water has absorbed, about 10 minutes, but watch your pasta and cook as needed until al dente. While pasta boils, brown the ground beef. To a large skillet, add the ground beef and cook over medium-high heat, breaking up the meat with a spatula as it cooks to ensure even cooking. After beef has cooked through, add the pasta sauce, stir to combine, and cook for 1 to 2 minutes, or until heated through. After pasta has cooked for about 10 minutes, or until all the water has been absorbed, add the sauce over the pasta and toss to combine in the skillet or alternatively plate the pasta and add sauce to each individual plate as desired.", new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CategoriesRecipes",
                columns: new[] { "CategoryId", "RecipeId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 8, 1 },
                    { 6, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 3 },
                    { 16, 3 },
                    { 16, 4 },
                    { 18, 4 },
                    { 21, 5 },
                    { 15, 6 },
                    { 2, 7 },
                    { 16, 7 },
                    { 20, 7 },
                    { 1, 8 },
                    { 2, 8 },
                    { 2, 9 },
                    { 20, 9 },
                    { 12, 10 },
                    { 4, 11 },
                    { 8, 11 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "CreatedOn", "DeletedOnUtc", "IsDeleted", "RecipeId", "Title", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { 1, "My grandchildren love these pancakes! They are a very good choice for a healthy breakfast!", new DateTime(2024, 10, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, "Fabulous!", new DateTime(2024, 10, 10, 12, 5, 0, 0, DateTimeKind.Unspecified), "edc8a753-f0dc-483f-bbaf-d26dc2827d54" },
                    { 2, "So delicious, yet so healthy!", new DateTime(2024, 10, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, "Awesome salad", null, "3b3c303f-b227-48d8-a30d-1932e90b058a" },
                    { 3, "I really need help. How long should I cook the beef strips for? I`m afraid they`ll end up raw...", new DateTime(2024, 12, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, "Need help!", null, "3b3c303f-b227-48d8-a30d-1932e90b058a" },
                    { 4, "Best banana bread ever!", new DateTime(2024, 12, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, 7, "Love", new DateTime(2024, 12, 13, 12, 5, 0, 0, DateTimeKind.Unspecified), "3b3c303f-b227-48d8-a30d-1932e90b058a" },
                    { 5, "I love this. Cheers to the creator!", new DateTime(2024, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, 6, "Great!", null, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" },
                    { 6, "I love this!", new DateTime(2024, 10, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, 9, "NOM NOM!", new DateTime(2024, 10, 30, 12, 5, 0, 0, DateTimeKind.Unspecified), "edc8a753-f0dc-483f-bbaf-d26dc2827d54" },
                    { 7, "Quick and easy, it is indeed a great recipe for fast dinner!", new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), null, false, 11, "Love it", new DateTime(2024, 10, 3, 10, 27, 0, 0, DateTimeKind.Unspecified), "edc8a753-f0dc-483f-bbaf-d26dc2827d54" }
                });

            migrationBuilder.InsertData(
                table: "RecipeImages",
                columns: new[] { "Id", "DeletedOnUtc", "IsDeleted", "RecipeId", "Url" },
                values: new object[,]
                {
                    { 1, null, false, 1, "https://images.unsplash.com/photo-1562281556-0f8c259a9f3a?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 2, null, false, 2, "https://plus.unsplash.com/premium_photo-1704989936092-c41f477cb6e2?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 3, null, false, 3, "https://images.unsplash.com/photo-1522248105696-9625ba87de6e?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 4, null, false, 4, "https://images.unsplash.com/photo-1596078841464-028efe9ddced?q=80&w=1964&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 5, null, false, 5, "https://media.istockphoto.com/id/817313114/photo/mushroom-beef-stroganoff-in-pan-with-copy-space.jpg?s=2048x2048&w=is&k=20&c=X6NMh7o18JfGseHdb1UwOzHWxpwC7kpwEDsJcvDrAms=" },
                    { 6, null, false, 6, "https://plus.unsplash.com/premium_photo-1664391870099-a7d4976fd8e9?q=80&w=1966&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 7, null, false, 8, "https://plus.unsplash.com/premium_photo-1700590072619-46364c033a1b?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fG1vY2hpfGVufDB8fDB8fHww" },
                    { 8, null, false, 8, "https://images.unsplash.com/photo-1629984169599-184e84223c1e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fG1vY2hpfGVufDB8fDB8fHww" },
                    { 9, null, false, 9, "https://images.unsplash.com/photo-1724424280324-7d8e35196bde?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8Y2hvY29jaGlwfGVufDB8fDB8fHww" },
                    { 10, null, false, 10, "https://plus.unsplash.com/premium_photo-1669559809094-1d6942e1531e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8cHVtcGtpbiUyMHNvdXB8ZW58MHx8MHx8fDA%3D" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "DeletedOnUtc", "IngredientId", "IsDeleted", "MeasurementUnitId", "Quantity", "RecipeId" },
                values: new object[,]
                {
                    { 1, null, 51, false, 1, 500L, 1 },
                    { 2, null, 7, false, 9, 2L, 1 },
                    { 3, null, 9, false, null, null, 1 },
                    { 4, null, 52, false, 8, 1L, 1 },
                    { 5, null, 5, false, null, null, 1 },
                    { 6, null, 48, false, null, null, 1 },
                    { 7, null, 54, false, 1, 250L, 2 },
                    { 8, null, 55, false, null, 1L, 2 },
                    { 9, null, 56, false, null, 5L, 2 },
                    { 10, null, 57, false, null, 1L, 2 },
                    { 11, null, 58, false, null, 1L, 2 },
                    { 12, null, 18, false, null, null, 2 },
                    { 13, null, 7, false, 9, 2L, 2 },
                    { 14, null, 59, false, 9, 1L, 2 },
                    { 15, null, 5, false, null, null, 2 },
                    { 16, null, 48, false, null, null, 2 },
                    { 17, null, 21, false, null, null, 2 },
                    { 18, null, 60, false, null, null, 2 },
                    { 19, null, 61, false, 1, 200L, 3 },
                    { 20, null, 2, false, null, 2L, 3 },
                    { 21, null, 42, false, 8, 1L, 3 },
                    { 22, null, 47, false, null, null, 3 },
                    { 23, null, 5, false, null, null, 3 },
                    { 24, null, 6, false, null, null, 3 },
                    { 25, null, 62, false, null, null, 3 },
                    { 26, null, 41, false, null, null, 3 },
                    { 27, null, 15, false, null, null, 3 },
                    { 28, null, 11, false, 1, 500L, 4 },
                    { 29, null, 63, false, null, 4L, 4 },
                    { 30, null, 8, false, null, 2L, 4 },
                    { 31, null, 9, false, null, 1L, 4 },
                    { 32, null, 19, false, null, 1L, 4 },
                    { 33, null, 10, false, null, 1L, 4 },
                    { 34, null, 58, false, null, 1L, 4 },
                    { 35, null, 60, false, null, null, 4 },
                    { 36, null, 69, false, null, null, 4 },
                    { 37, null, 53, false, null, null, 4 },
                    { 38, null, 45, false, null, null, 4 },
                    { 39, null, 50, false, null, null, 4 },
                    { 40, null, 7, false, 8, 2L, 4 },
                    { 41, null, 65, false, 1, 200L, 5 },
                    { 42, null, 70, false, 1, 300L, 5 },
                    { 43, null, 10, false, null, 2L, 5 },
                    { 44, null, 22, false, 1, 250L, 5 },
                    { 45, null, 9, false, null, null, 5 },
                    { 46, null, 66, false, 8, 2L, 5 },
                    { 47, null, 67, false, 8, 1L, 5 },
                    { 48, null, 68, false, 1, 100L, 5 },
                    { 49, null, 21, false, null, null, 5 },
                    { 50, null, 7, false, 10, 1L, 6 },
                    { 51, null, 2, false, null, 1L, 6 },
                    { 52, null, 18, false, null, null, 6 },
                    { 53, null, 66, false, 9, 1L, 6 },
                    { 54, null, 5, false, null, null, 6 },
                    { 55, null, 48, false, null, null, 6 },
                    { 56, null, 71, false, null, 2L, 7 },
                    { 57, null, 6, false, 1, 80L, 7 },
                    { 58, null, 5, false, null, null, 7 },
                    { 59, null, 42, false, 9, 1L, 7 },
                    { 60, null, 75, false, 1, 150L, 7 },
                    { 61, null, 2, false, null, 1L, 7 },
                    { 62, null, 47, false, null, null, 7 },
                    { 63, null, 72, false, 1, 200L, 7 },
                    { 64, null, 79, false, 10, 1L, 8 },
                    { 65, null, 81, false, 10, 1L, 8 },
                    { 66, null, 85, false, 10, 1L, 8 },
                    { 67, null, 86, false, 8, 1L, 8 },
                    { 68, null, 76, false, 1, 100L, 8 },
                    { 69, null, 95, false, 1, 50L, 8 },
                    { 70, null, 6, false, 10, 1L, 9 },
                    { 71, null, 3, false, 10, 1L, 9 },
                    { 72, null, 75, false, 10, 1L, 9 },
                    { 73, null, 47, false, 8, 2L, 9 },
                    { 74, null, 1, false, 10, 3L, 9 },
                    { 75, null, 42, false, 8, 1L, 9 },
                    { 76, null, 5, false, 8, 1L, 9 },
                    { 77, null, 92, false, 10, 2L, 9 },
                    { 78, null, 7, false, 9, 6L, 10 },
                    { 79, null, 93, false, null, null, 10 },
                    { 80, null, 10, false, null, null, 10 },
                    { 81, null, 9, false, null, null, 10 },
                    { 82, null, 5, false, null, null, 10 },
                    { 83, null, 44, false, null, null, 10 },
                    { 84, null, 94, false, null, null, 10 },
                    { 85, null, 48, false, null, null, 10 },
                    { 86, null, 96, false, 10, 4L, 10 },
                    { 87, null, 24, false, 7, 100L, 10 },
                    { 88, null, 41, false, 9, 2L, 10 },
                    { 89, null, 98, false, 1, 100L, 10 },
                    { 90, null, 51, false, 4, 12L, 11 },
                    { 91, null, 5, false, null, null, 11 },
                    { 92, null, 20, false, null, null, 11 },
                    { 93, null, 82, false, null, null, 11 },
                    { 94, null, 12, false, 5, 1L, 11 }
                });

            migrationBuilder.InsertData(
                table: "RecipeRatings",
                columns: new[] { "Id", "DeletedOnUtc", "IsDeleted", "RecipeId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, null, false, 3, "edc8a753-f0dc-483f-bbaf-d26dc2827d54", 5 },
                    { 2, null, false, 2, "edc8a753-f0dc-483f-bbaf-d26dc2827d54", 4 },
                    { 3, null, false, 5, "edc8a753-f0dc-483f-bbaf-d26dc2827d54", 5 },
                    { 4, null, false, 1, "3b3c303f-b227-48d8-a30d-1932e90b058a", 5 },
                    { 5, null, false, 4, "f44c3f06-172b-491e-b71d-8672ac7595cb", 5 }
                });

            migrationBuilder.InsertData(
                table: "UsersFavoriteRecipes",
                columns: new[] { "RecipeId", "UserId" },
                values: new object[,]
                {
                    { 1, "3b3c303f-b227-48d8-a30d-1932e90b058a" },
                    { 2, "3b3c303f-b227-48d8-a30d-1932e90b058a" },
                    { 7, "3b3c303f-b227-48d8-a30d-1932e90b058a" },
                    { 8, "3b3c303f-b227-48d8-a30d-1932e90b058a" },
                    { 9, "3b3c303f-b227-48d8-a30d-1932e90b058a" },
                    { 2, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" },
                    { 3, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" },
                    { 5, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" },
                    { 6, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" },
                    { 7, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" },
                    { 11, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Body", "CommentId", "CreatedOn", "DeletedOnUtc", "IsDeleted", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { 1, "Generally the beef strips need to be seared, not completely cooked so anything between 3 to 5 minutes at max heat.", 3, new DateTime(2024, 12, 10, 1, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(2024, 10, 3, 1, 27, 0, 0, DateTimeKind.Unspecified), "1a575c2a-065c-487a-8b56-cfd897b1b5ce" },
                    { 2, "Thank you! :)", 3, new DateTime(2024, 10, 14, 2, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "3b3c303f-b227-48d8-a30d-1932e90b058a" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DisplayName",
                table: "AspNetUsers",
                column: "DisplayName",
                unique: true,
                filter: "[DisplayName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IsDeleted",
                table: "Categories",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesRecipes_CategoryId",
                table: "CategoriesRecipes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IsDeleted",
                table: "Comments",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RecipeId",
                table: "Comments",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CookingRanks_IsDeleted",
                table: "CookingRanks",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_CookingRankId",
                table: "Cooks",
                column: "CookingRankId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_IsDeleted",
                table: "Cooks",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_UserId",
                table: "Cooks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IsDeleted",
                table: "Ingredients",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnits_IsDeleted",
                table: "MeasurementUnits",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeImages_IsDeleted",
                table: "RecipeImages",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeImages_RecipeId",
                table: "RecipeImages",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IsDeleted",
                table: "RecipeIngredients",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_MeasurementUnitId",
                table: "RecipeIngredients",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRatings_IsDeleted",
                table: "RecipeRatings",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRatings_RecipeId",
                table: "RecipeRatings",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRatings_UserId",
                table: "RecipeRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CookId",
                table: "Recipes",
                column: "CookId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IsDeleted",
                table: "Recipes",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_CommentId",
                table: "Replies",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_IsDeleted",
                table: "Replies",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserId",
                table: "Replies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFavoriteRecipes_RecipeId",
                table: "UsersFavoriteRecipes",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CategoriesRecipes");

            migrationBuilder.DropTable(
                name: "RecipeImages");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeRatings");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "UsersFavoriteRecipes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "MeasurementUnits");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Cooks");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CookingRanks");
        }
    }
}
