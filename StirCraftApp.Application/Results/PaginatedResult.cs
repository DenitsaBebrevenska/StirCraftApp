using StirCraftApp.Application.DTOs;

namespace StirCraftApp.Application.Results;

public class PaginatedResult<T>(int pageIndex, int pageSize, int count, IList<T> data) where T : BaseDto
{
    public int PageIndex { get; init; } = pageIndex;
    public int PageSize { get; init; } = pageSize;
    public int Count { get; init; } = count;
    public IList<T> Data { get; init; } = data;
}
