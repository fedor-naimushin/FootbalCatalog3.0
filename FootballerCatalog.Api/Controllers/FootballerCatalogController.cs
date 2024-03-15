using FluentValidation;
using FootballerCatalog.Application.Services;
using FootballerCatalog.Contracts.Footballer;
using FootballerCatalog.Domain.Interfaces;
using FootballerCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FootballerCatalog.Controllers;

public class FootballerCatalogController : ApiController
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

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getFootballer = await _footballerService.GetById(id);

        return getFootballer.Match(
            footballer => Ok(MapFootballerResponse(footballer)),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateFootballer(FootballerRequest request)
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

        var createdResult = await _footballerService.CreateFootballer(footballer);

        if (createdResult.IsError)
        {
            return Problem(createdResult.Errors);
        }

        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { id = footballer.Id },
            value: MapFootballerResponse(footballer)
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateFootballer(Guid id, [FromBody] FootballerRequest request)
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

        var updateResult = await _footballerService.UpdateFootballer(id, request);

        if (updateResult.IsError)
        {
            return Problem(updateResult.Errors);
        }

        return updateResult.Match(
            f => Ok(MapFootballerResponse(footballer)),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteFootballer(Guid id)
    {
        var deletedResult = await _footballerService.DeleteFootballer(id);

        return deletedResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }


    private static Footballer MapFootballerResponse(Footballer footballer)
    {
        var response = new Footballer(
            footballer.Id,
            footballer.FirstName,
            footballer.LastName,
            footballer.Gender,
            footballer.Birthday,
            footballer.TeamTitle,
            footballer.Country
        );
        return response;
    }
}