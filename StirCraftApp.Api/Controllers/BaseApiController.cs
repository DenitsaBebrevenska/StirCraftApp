using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.RequestHelpers;
using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    protected async Task<IActionResult> CreatePagedResult<T>(IUnitOfWork unit,
        ISpecification<T> spec, int pageIndex, int pageSize) where T : class
    {
        var items = await unit.Repository<T>().GetAllWithSpecAsync(spec);
        var count = items.Count();

        var paginatedResult = new Pagination<T>(pageIndex, pageSize, count, items);

        return Ok(paginatedResult);
    }
}
