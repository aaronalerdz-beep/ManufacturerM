using System.Security.Claims;
using API.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BuggyController : BaseApiController
{
    [HttpGet("unauthorized")]
    public IActionResult GetUnauthorized()
    {
        return Unauthorized();
    }
    [HttpGet("notfound")]
    public IActionResult GetNotFound()
    {
        return NotFound();
    }
    [HttpGet("badrequest")]
    public IActionResult GetBadRequest()
    {
        return BadRequest("Not a goog request");
    }
    [HttpGet("internalerror")]
    public IActionResult GetInternalError()
    {
        throw new Exception("this is a test exception");
    }

    [HttpPost("validationparterror")]
    public IActionResult GetValidationError(CreatePartDto part)
    {
        return Ok();
    }
[Authorize]
[HttpGet("secret")]
public IActionResult GetSecret()
{
    var name = User.FindFirst(ClaimTypes.Name)?.Value;
    var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    return Ok("Hello " + name + "with the id of " + id);
    
}
}

