using Microsoft.AspNetCore.Mvc;

namespace FootballerCatalog.Controllers;

[ApiController]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public  IActionResult Error()
    {
        return Problem();
    }
}