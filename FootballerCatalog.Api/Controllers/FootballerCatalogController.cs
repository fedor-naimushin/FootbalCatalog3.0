using FootballerCatalog.Application.Services;
using FootballerCatalog.Contracts.Footballer;

using Microsoft.AspNetCore.Mvc;

namespace FootballerCatalog.Controllers;

[ApiController]
[Route("[controller]")]
public class FootballerCatalogController : ControllerBase
{
    private readonly IFootballersService _footballerService;

    public FootballerCatalogController(IFootballersService footballerService)
    {
        _footballerService = footballerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<FootballerResponse>>> GetAllFootballers()
    {
        var footballers = await _footballerService.GetAllFootballers();

        var response = footballers
            .Select(f => new FootballerResponse(
                f.Id,
                f.FirstName,
                f.LastName,
                f.Gender,
                f.Birthday,
                f.TeamTitle,
                f.Country
            ));

        return Ok(response);
    }
}