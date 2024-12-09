namespace StirCraftApp.Domain.Specifications.SpecParams;
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
