using StirCraftApp.Application.DTOs;

namespace StirCraftApp.Application.Results;

/// <summary>
/// Represents a paginated result set with metadata about the pagination state.
/// </summary>
/// <typeparam name="T">The type of the data items, which must inherit from BaseDto.</typeparam>
/// <param name="pageIndex">The current page index (zero-based).</param>
/// <param name="pageSize">The number of items per page.</param>
/// <param name="count">The total number of items available.</param>
/// <param name="data">The list of data items for the current page.</param>
public class PaginatedResult<T>(int pageIndex, int pageSize, int count, IList<T> data) where T : BaseDto
{
    public int PageIndex { get; init; } = pageIndex;
    public int PageSize { get; init; } = pageSize;
    public int Count { get; init; } = count;
    public IList<T> Data { get; init; } = data;
}
