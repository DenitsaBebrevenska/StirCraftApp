namespace StirCraftApp.Domain.Specifications.SpecParams;
public class IngredientSpecParams : PagingParams
{
    private string? _ingredientName;

    public string IngredientName
    {
        get => _ingredientName ?? string.Empty;
        set => _ingredientName = value.ToLower();
    }
}
