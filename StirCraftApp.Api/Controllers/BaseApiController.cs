using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StirCraftApp.Api.Controllers;

/// <summary>
/// Base class for all API controllers, which provides authorization and routing by default behavior.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseApiController : ControllerBase
{
}
