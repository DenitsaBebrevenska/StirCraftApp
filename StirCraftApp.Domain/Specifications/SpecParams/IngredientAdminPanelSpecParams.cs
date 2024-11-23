namespace StirCraftApp.Domain.Specifications.SpecParams;
public class IngredientAdminPanelSpecParams : PagingParams
{
    private string? _ingredientName;
    public string IngredientName
    {
        get => _ingredientName ?? string.Empty;
        set => _ingredientName = value.ToLower();
    }

    private bool? _isAdminApproved;

    public bool? IsAdminApproved
    {
        get => _isAdminApproved;
        set => _isAdminApproved = value;
    }


}
