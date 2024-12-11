namespace StirCraftApp.Domain.Specifications.SpecParams;

/// <summary>
///  A class that contains the parameters for filtering ingredients for the admin panel
/// Inherits from Paging params therefor it has the properties for pagination
/// </summary>
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
