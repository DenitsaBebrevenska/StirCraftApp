namespace StirCraftApp.Domain.Specifications.SpecParams;

/// <summary>
/// This class is used to set the paging parameters for the query
/// </summary>
public class PagingParams
{
    private const int MaxPageSize = 50;

    public int PageIndex { get; set; } = 1;

    private int _pageSize = 5;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}
