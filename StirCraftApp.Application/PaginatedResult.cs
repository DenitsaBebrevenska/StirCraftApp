namespace StirCraftApp.Application;

public class PaginatedResult(int pageIndex, int pageSize, int count, IList<object> data)
{
    public int PageIndex { get; set; } = pageIndex;
    public int PageSize { get; set; } = pageSize;
    public int Count { get; set; } = count;
    public IList<object> Data { get; set; } = data;
}
