using FootballerCatalog.Application.Services;
using FootballerCatalog.Contracts.Footballer;
using FootballerCatalog.Models;

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

    [HttpPost]
    public IActionResult CreateFootballer(FootballerRequest request)
    {
        return Ok(request);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetFootballer(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertFootballer(Guid id, UpsertFootballerRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteFootballer(Guid id)
    {
        return Ok(id);
    }
}