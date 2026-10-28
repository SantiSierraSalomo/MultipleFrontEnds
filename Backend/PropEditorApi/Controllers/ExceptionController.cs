using Microsoft.AspNetCore.Mvc;
using PropEditorApi.Services;

namespace PropEditorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Diagnostics / Exceptions")]
public class ExceptionController(IExceptionService service) : ControllerBase
{
    [HttpGet("not-found")]
    public IActionResult RaiseNotFound()
    {
        service.ThrowNotFound();
        return Ok();
    }

    [HttpGet("validation")]
    public IActionResult RaiseValidation()
    {
        service.ThrowValidation();
        return Ok();
    }

    [HttpGet("conflict")]
    public IActionResult RaiseConflict()
    {
        service.ThrowConflict();
        return Ok();
    }

    [HttpGet("unexpected")]
    public IActionResult RaiseUnexpected()
    {
        service.ThrowUnexpected();
        return Ok();
    }
}
