using FootballerCatalog.Contracts.Footballer;
using FootballerCatalog.Models;
using FootballerCatalog.Services.Footballer;
using Microsoft.AspNetCore.Mvc;

namespace FootballerCatalog.Controllers;

[ApiController]
[Route("[controller]")]
public class FootballerCatalogController : ControllerBase
{
    private readonly IFootballerService _footballerService;

    public FootballerCatalogController(IFootballerService footballerService)
    {
        _footballerService = footballerService;
    }

    [HttpPost]
    public IActionResult CreateFootballer(FootballerRequest request)
    {
        var footballer = new Footballer(
            Guid.NewGuid(),
            request.FirstName,
            request.LastName,
            request.Gender,
            request.Birthday,
            request.TeamTitle,
            request.Country
        );
        
        _footballerService.Create(footballer);
        
        var response = new FootballerResponse(
            footballer.Id,
            footballer.FirstName,
            footballer.LastName,
            footballer.Gender,
            footballer.Birthday,
            footballer.TeamTitle,
            footballer.Country
        );
        
        return CreatedAtAction(
            nameof(GetFootballer),
            new {id = footballer.Id},
            value: response
        );
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