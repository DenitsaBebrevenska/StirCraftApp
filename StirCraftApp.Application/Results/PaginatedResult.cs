using StirCraftApp.Application.DTOs;

namespace StirCraftApp.Application.Results;

public class PaginatedResult<T>(int pageIndex, int pageSize, int count, IList<T> data) where T : BaseDto
{
    public int PageIndex { get; set; } = pageIndex;
    public int PageSize { get; set; } = pageSize;
    public int Count { get; set; } = count;
    public IList<T> Data { get; set; } = data;
}
