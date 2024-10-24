namespace StirCraftApp.Domain.Specifications;
public class RecipeSpecParams : PagingParams
{
    private string? _recipeName;

    private List<string> _categories = new List<string>();

    private List<string> _difficultyLevels = new List<string>();

    public string RecipeName
    {
        get => _recipeName ?? string.Empty;
        set => _recipeName = value.ToLower();
    }

    public List<string> Categories
    {
        get => _categories;
        set => _categories = value.SelectMany(x => x.Split(',',
            StringSplitOptions.RemoveEmptyEntries))
            .ToList();
    }

    public List<string> DifficultyLevels
    {
        get => _difficultyLevels;
        set => _difficultyLevels = value.SelectMany(x => x.Split(',',
                StringSplitOptions.RemoveEmptyEntries))
            .ToList();
    }

    public string? Sort { get; set; }

}
