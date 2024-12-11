namespace StirCraftApp.Domain.Constants;

/// <summary>
/// Constants for caching values
/// </summary>
public static class CachingValues
{
    public const int ModerateSlidingSeconds = 60;
    public const int ModerateAbsoluteSeconds = 600;

    public const int QuickSlidingSeconds = 30;
    public const int QuickAbsoluteSeconds = 300;

    public const int GenerousSlidingSeconds = 120;
    public const int GenerousAbsoluteSeconds = 1200;

    public const string RecipesCachePattern = "api/recipes";
    public const string RecipeAdminCachePattern = "api/admin/recipes/pending-approval";
    public const string CookOwnRecipesCachePattern = "api/cook/recipe";
    public const string IngredientsCachePattern = "api/ingredients";
    public const string IngredientsAdminCachePattern = "api/admin/ingredients";
    public const string CooksCachePattern = "api/cooks|";


}
