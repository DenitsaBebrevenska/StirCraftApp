using Microsoft.AspNetCore.Identity;
using Moq;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.ImageDtos;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Services;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Enums;
using StirCraftApp.Domain.JoinedTables;
using Xunit;
using static StirCraftApp.Domain.Constants.GlobalConstants;

namespace StirCraftApp.Tests;

public class RecipeUnitServiceTests
{
    public class RecipeServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<ICookingRankService> _mockCookingRankService;
        private readonly RecipeService _recipeService;
        private readonly Mock<IRepository<Recipe>> _mockRecipeRepository;
        private readonly Mock<IRepository<Cook>> _mockCookRepository;
        private readonly Mock<IRepository<RecipeRating>> _mockRecipeRatingRepository;

        private static readonly Cook TestCook1 = new()
        {
            Id = 1,
            UserId = "user111",
            AppUser = new AppUser
            {
                Id = "user111",
                DisplayName = "Cook1"
            },
            About = "About1"
        };

        private static readonly Recipe TestRecipe1 = new Recipe()
        {
            Id = 1,
            Name = "Recipe1",
            PreparationSteps = "Recipe1 Steps",
            CookId = TestCook1.Id,
            Cook = TestCook1,
            DifficultyLevel = DifficultyLevel.Easy,
            CreatedOn = DateTime.UtcNow,
            UpdatedOn = DateTime.UtcNow,
            RecipeRatings = new List<RecipeRating>()
            {
                new RecipeRating()
                {
                    Value =5,
                    UserId = "user111122323",
                    RecipeId = 1
                }
            },
            RecipeIngredients = new List<RecipeIngredient>()
            {
                new RecipeIngredient()
                {
                    Id = 1,
                    Ingredient = new Ingredient
                    {
                        Id = 11,
                        Name = "Ingredient11",
                        IsAdminApproved = true,
                        IsAllergen = false
                    },
                    IngredientId = 11,
                    Quantity = 2,
                    MeasurementUnitId = 4,
                    MeasurementUnit = new MeasurementUnit
                    {
                        Id = 4,
                        Name = "Unit4",
                        Abbreviation = "U4"
                    }
                },
                new RecipeIngredient()
                {
                    Id = 2,
                    Ingredient = new Ingredient
                    {
                        Id = 44,
                        Name = "Ingredient44",
                        IsAdminApproved = true,
                        IsAllergen = false
                    },
                    IngredientId = 44,
                    Quantity = 7,
                    MeasurementUnitId = 2,
                    MeasurementUnit = new MeasurementUnit
                    {
                        Id = 2,
                        Name = "Unit2",
                        Abbreviation = "U2"
                    }
                }
            },
            UserFavoriteRecipes = new List<UserFavoriteRecipe>()
            {
                new UserFavoriteRecipe()
                {
                    UserId = "user1010",
                    RecipeId = 1
                }
            }

        };

        private static readonly Recipe TestRecipe2 = new Recipe()
        {
            Id = 2,
            Name = "Recipe2",
            PreparationSteps = "Recipe1 Steps",
            CookId = 2,
            Cook = new Cook
            {
                Id = 2,
                UserId = "user222",
                AppUser = new AppUser
                {
                    Id = "user222",
                    DisplayName = "Cook2"
                },
                About = "About2"
            },
            DifficultyLevel = DifficultyLevel.Easy,
            CreatedOn = DateTime.UtcNow,
            UpdatedOn = DateTime.UtcNow,
            RecipeIngredients = new List<RecipeIngredient>()
            {
                new RecipeIngredient()
                {
                    Id = 1,
                    Ingredient = new Ingredient
                    {
                        Id = 11,
                        Name = "Ingredient11",
                        IsAdminApproved = true,
                        IsAllergen = false
                    },
                    IngredientId = 11,
                    Quantity = 2,
                    MeasurementUnitId = 4,
                    MeasurementUnit = new MeasurementUnit
                    {
                        Id = 4,
                        Name = "Unit4",
                        Abbreviation = "U4"
                    }
                },
                new RecipeIngredient()
                {
                    Id = 2,
                    Ingredient = new Ingredient
                    {
                        Id = 44,
                        Name = "Ingredient44",
                        IsAdminApproved = true,
                        IsAllergen = false
                    },
                    IngredientId = 44,
                    Quantity = 7,
                    MeasurementUnitId = 2,
                    MeasurementUnit = new MeasurementUnit
                    {
                        Id = 2,
                        Name = "Unit2",
                        Abbreviation = "U2"
                    }
                }
            }
        };

        private readonly List<Recipe> _testRecipes = new List<Recipe>()
        {
            TestRecipe1,
            TestRecipe2
        };

        public RecipeServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockCookingRankService = new Mock<ICookingRankService>();
            var userStoreMock = new Mock<IUserStore<AppUser>>();
            Mock<UserManager<AppUser>> mockUserManager = new(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            _recipeService = new RecipeService(
                _mockUnitOfWork.Object,
                _mockCookingRankService.Object,
                mockUserManager.Object
            );

            _mockRecipeRepository = new Mock<IRepository<Recipe>>();
            _mockCookRepository = new Mock<IRepository<Cook>>();
            _mockRecipeRatingRepository = new Mock<IRepository<RecipeRating>>();
            _mockUnitOfWork.Setup(u => u.Repository<Recipe>()).Returns(_mockRecipeRepository.Object);
            _mockUnitOfWork.Setup(u => u.Repository<Cook>()).Returns(_mockCookRepository.Object);
            _mockUnitOfWork.Setup(u => u.Repository<RecipeRating>()).Returns(_mockRecipeRatingRepository.Object);
        }


        #region GetRecipeByIdAsync Tests

        [Fact]
        public async Task GetRecipeByIdAsync_ExistingRecipe_ReturnsDto()
        {
            var expectedDto = new DetailedRecipeDto()
            {
                Id = TestRecipe1.Id,
                Name = TestRecipe1.Name,
                PreparationSteps = TestRecipe1.PreparationSteps,
                DifficultyLevel = TestRecipe1.DifficultyLevel.ToString(),
                CookName = TestRecipe1.Cook.AppUser.DisplayName!,
                CookId = TestRecipe1.CookId,
                CreatedOn = TestRecipe1.CreatedOn.ToString(DateFormat),
                UpdatedOn = TestRecipe1.UpdatedOn.ToString(DateFormat)
            };

            _mockRecipeRepository.Setup(r => r.GetByIdAsync(It.IsAny<ISpecification<Recipe>>(), TestRecipe1.Id))
                .ReturnsAsync(TestRecipe1);

            var result = await _recipeService.GetRecipeByIdAsync<DetailedRecipeDto>(
                null,
                TestRecipe1.Id,
                r => Task.FromResult(expectedDto)
            );

            Assert.Equal(expectedDto, result);
        }

        [Fact]
        public async Task GetRecipeByIdAsync_NonExistingRecipe_ThrowsNotFoundException()
        {
            var expectedDto = new DetailedRecipeDto()
            {
                Id = TestRecipe1.Id,
                Name = TestRecipe1.Name,
                PreparationSteps = TestRecipe1.PreparationSteps,
                DifficultyLevel = TestRecipe1.DifficultyLevel.ToString(),
                CookName = TestRecipe1.Cook.AppUser.DisplayName!,
                CookId = TestRecipe1.CookId,
                CreatedOn = TestRecipe1.CreatedOn.ToString(DateFormat),
                UpdatedOn = TestRecipe1.UpdatedOn.ToString(DateFormat)
            };

            _mockRecipeRepository.Setup(r => r.GetByIdAsync(It.IsAny<ISpecification<Recipe>>(), TestRecipe1.Id))
                .ReturnsAsync((Recipe)null);

            await Assert.ThrowsAsync<NotFoundException>(() =>
                _recipeService.GetRecipeByIdAsync<DetailedRecipeDto>(
                    null,
                    TestRecipe1.Id,
                    r => Task.FromResult(expectedDto)
                )
            );
        }
        #endregion

        #region GetRecipesAsync Tests
        [Fact]
        public async Task GetRecipesAsync_ReturnsCorrectPaginatedResult()
        {
            var expectedDto = new DetailedRecipeDto()
            {
                Id = TestRecipe1.Id,
                Name = TestRecipe1.Name,
                PreparationSteps = TestRecipe1.PreparationSteps,
                DifficultyLevel = TestRecipe1.DifficultyLevel.ToString(),
                CookName = TestRecipe1.Cook.AppUser.DisplayName!,
                CookId = TestRecipe1.CookId,
                CreatedOn = TestRecipe1.CreatedOn.ToString(DateFormat),
                UpdatedOn = TestRecipe1.UpdatedOn.ToString(DateFormat)
            };

            var spec = new Mock<ISpecification<Recipe>>().Object;
            var expectedCount = _testRecipes.Count;

            _mockRecipeRepository.Setup(r => r.GetAllAsync(spec))
                .ReturnsAsync(_testRecipes);
            _mockRecipeRepository.Setup(r => r.CountAsync(spec))
                .ReturnsAsync(expectedCount);

            var result = await _recipeService.GetRecipesAsync<DetailedRecipeDto>(
                spec,
                r => Task.FromResult(expectedDto)
            );


            Assert.Equal(expectedCount, result.Data.Count);
        }
        #endregion

        #region CreateRecipeAsync Tests
        [Fact]
        public async Task CreateRecipeAsync_ValidDto_CreatesRecipe()
        {
            var createRecipeDto = new FormRecipeDto
            {
                Name = "Recipe1",
                PreparationSteps = "Recipe1 Steps",
                DifficultyLevel = DifficultyLevel.Easy.ToString(),
                RecipeIngredients = new List<FormRecipeIngredientDto>
                {
                    new FormRecipeIngredientDto
                    {
                        IngredientId = 11,
                        Quantity = 2,
                        MeasurementUnitId = 4
                    },
                    new FormRecipeIngredientDto
                    {
                        IngredientId = 44,
                        Quantity = 7,
                        MeasurementUnitId = 2
                    }
                }
            };
            _mockCookRepository.Setup(r => r.GetByIdAsync(null, TestRecipe1.CookId))
                .ReturnsAsync(TestCook1);

            _mockRecipeRepository.Setup(r => r.AddAsync(It.IsAny<Recipe>()))
                .Callback<Recipe>(r => r.Id = TestRecipe1.Id);

            _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(true);

            var result = await _recipeService.CreateRecipeAsync(createRecipeDto, TestCook1.Id);

            _mockUnitOfWork.Verify(u => u.Repository<Recipe>().AddAsync(It.IsAny<Recipe>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
        }
        #endregion

        #region UpdateRecipeAsync Tests
        [Fact]
        public async Task UpdateRecipeAsync_IdMismatch_ThrowsValidationException()
        {
            var updateDto = new EditFormRecipeDto
            {
                Id = TestRecipe1.Id + 1,
                Name = "Recipe1",
                PreparationSteps = "Recipe1 Steps",
                DifficultyLevel = DifficultyLevel.Easy.ToString(),
            };

            await Assert.ThrowsAsync<ValidationException>(() =>
                _recipeService.UpdateRecipeAsync(TestRecipe1.Id, updateDto)
            );
        }

        [Fact]
        public async Task UpdateRecipeAsync_ValidUpdate_UpdatesRecipe()
        {

            var updateDto = new EditFormRecipeDto
            {
                Id = TestRecipe1.Id,
                Name = "RecipeNameEdited",
                PreparationSteps = "Recipe1 Steps Edited",
                DifficultyLevel = DifficultyLevel.Medium.ToString(),
                CategoryRecipes = new List<int>(),
                RecipeIngredients = new List<FormRecipeIngredientDto>(),
                RecipeImages = new List<RecipeImageDto>()
            };

            _mockRecipeRepository.Setup(r => r.GetByIdAsync(It.IsAny<ISpecification<Recipe>>(), TestRecipe1.Id))
                 .ReturnsAsync(TestRecipe1);

            _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(true);

            await _recipeService.UpdateRecipeAsync(TestRecipe1.Id, updateDto);

            _mockUnitOfWork.Verify(u => u.Repository<Recipe>().Update(It.IsAny<Recipe>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
        }
        #endregion

        #region DeleteRecipeAsync Tests
        [Fact]
        public async Task DeleteRecipeAsync_DeletesRecipeAndCalculatesPoints()
        {
            _mockRecipeRepository.Setup(r => r.GetByIdAsync(null, TestRecipe1.Id))
                 .ReturnsAsync(TestRecipe1);

            _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(true);
            _mockCookingRankService.Setup(s => s.CalculatePoints(TestRecipe1.CookId, It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            await _recipeService.DeleteRecipeAsync(TestRecipe1.Id);

            // Assert
            _mockUnitOfWork.Verify(u => u.Repository<Recipe>().Delete(TestRecipe1), Times.Once);
            _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
            _mockCookingRankService.Verify(s => s.CalculatePoints(TestRecipe1.CookId, It.IsAny<string>()), Times.Once);
        }
        #endregion

        #region ToggleFavoriteAsync Tests
        [Fact]
        public async Task ToggleFavoriteAsync_AddFavorite_ReturnsCorrectDto()
        {
            var userId = "user1111";
            _mockRecipeRepository.Setup(r => r.GetAllAsync(It.IsAny<ISpecification<Recipe>>()))
                .ReturnsAsync(new List<Recipe> { TestRecipe1 });

            _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(true);
            _mockCookingRankService.Setup(s => s.CalculatePoints(TestRecipe1.CookId, It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var result = await _recipeService.ToggleFavoriteAsync(userId, TestRecipe1.Id);

            var expectedDto = new FavoriteRecipeToggleDto
            {
                IsFavorite = true,
                TotalLikes = 2
            };

            Assert.True(result.IsFavorite);
            Assert.Equal(expectedDto.IsFavorite, result.IsFavorite);
            Assert.Equal(expectedDto.TotalLikes, result.TotalLikes);
            _mockCookingRankService.Verify(s => s.CalculatePoints(TestRecipe1.CookId, It.IsAny<string>()), Times.Once);
        }


        [Fact]
        public async Task ToggleFavoriteAsync_RemoveFavorite_ReturnsCorrectDto()
        {
            var userId = "user1010";

            _mockRecipeRepository.Setup(r => r.GetAllAsync(It.IsAny<ISpecification<Recipe>>()))
                .ReturnsAsync(new List<Recipe> { TestRecipe1 });

            _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(true);
            _mockCookingRankService.Setup(s => s.CalculatePoints(TestRecipe1.CookId, It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            var expectedDto = new FavoriteRecipeToggleDto
            {
                IsFavorite = false,
                TotalLikes = 0
            };


            var result = await _recipeService.ToggleFavoriteAsync(userId, TestRecipe1.Id);

            Assert.False(result.IsFavorite);
            Assert.Equal(expectedDto.TotalLikes, result.TotalLikes);
            Assert.Equal(expectedDto.IsFavorite, result.IsFavorite);
            _mockCookingRankService.Verify(s => s.CalculatePoints(TestRecipe1.CookId, It.IsAny<string>()), Times.Once);
        }
        #endregion

        #region RateRecipeAsync Tests
        [Fact]
        public async Task RateRecipeAsync_ValidRating_UpdatesRating()
        {
            var userId = "user1";
            var rating = 4;

            _mockRecipeRepository.Setup(r => r.GetByIdAsync(null, TestRecipe1.Id))
                .ReturnsAsync(TestRecipe1);

            _mockRecipeRatingRepository.Setup(r => r.AddAsync(It.IsAny<RecipeRating>()))
                .Callback<RecipeRating>(rr => TestRecipe1.RecipeRatings.Add(rr))
                .Returns(Task.CompletedTask);

            _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(true);

            var result = await _recipeService.RateRecipeAsync(userId, TestRecipe1.Id, rating);

            var expectedResult = 4.5;
            Assert.Equal(expectedResult, result);
            _mockRecipeRatingRepository.Verify(r => r.AddAsync(It.IsAny<RecipeRating>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task RateRecipeAsync_InvalidRating_ThrowsValidationException()
        {
            var userId = "user1";
            var invalidRating = 200;

            _mockRecipeRepository.Setup(r => r.GetByIdAsync(null, TestRecipe1.Id))
                .ReturnsAsync(TestRecipe1);

            await Assert.ThrowsAsync<ValidationException>(() =>
                _recipeService.RateRecipeAsync(userId, TestRecipe1.Id, invalidRating)
            );
        }
        #endregion

        #region ApproveRecipeAsync Tests
        [Fact]
        public async Task ApproveRecipeAsync_ApprovesRecipeAndCalculatesPoints()
        {
            _mockRecipeRepository.Setup(r => r.GetByIdAsync(null, TestRecipe1.Id))
                .ReturnsAsync(TestRecipe1);

            _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(true);
            _mockCookingRankService.Setup(s => s.CalculatePoints(TestRecipe1.CookId, It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            await _recipeService.ApproveRecipeAsync(TestRecipe1.Id);

            Assert.True(TestRecipe1.IsAdminApproved);
            _mockUnitOfWork.Verify(u => u.Repository<Recipe>().Update(TestRecipe1), Times.Once);
            _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
            _mockCookingRankService.Verify(s => s.CalculatePoints(TestRecipe1.CookId, It.IsAny<string>()), Times.Once);
        }
        #endregion
    }
}
