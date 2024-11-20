namespace StirCraftApp.Domain.Specifications.SpecParams;
public class IngredientSpecParams : PagingParams
{
    private string? _name;

    public string Name
    {
        get => _name ?? string.Empty;
        set => _name = value.ToLower();
    }
}
