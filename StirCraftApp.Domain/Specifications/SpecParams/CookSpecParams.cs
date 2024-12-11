namespace StirCraftApp.Domain.Specifications.SpecParams;

/// <summary>
///  A class that contains the parameters for filtering cooks
/// Inherits from Paging params therefor it has the properties for pagination
/// </summary>
public class CookSpecParams : PagingParams
{
    private string? _cookName;
    public string? Sort { get; set; }

    public string CookName
    {
        get => _cookName ?? string.Empty;
        set => _cookName = value;
    }

}
