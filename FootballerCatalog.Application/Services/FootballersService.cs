using FootballerCatalog.Contracts.Footballer;
using FootballerCatalog.Domain.Interfaces;
using FootballerCatalog.Models;
using ErrorOr;

namespace FootballerCatalog.Application.Services;

public class FootballersService : IFootballersService
{
    private readonly IFootballersRepository _footballersRepository;

    public FootballersService(IFootballersRepository footballersRepository)
    {
        _footballersRepository = footballersRepository;
    }

    public async Task<List<Footballer>> GetAllFootballers()
    {
        return await _footballersRepository.GetAll();
    }

    public async Task<ErrorOr<Footballer>> GetById(Guid id)
    {
        var footballer = await _footballersRepository.GeById(id);
        
        if (footballer != null)
            return footballer;

        return ErrorsService.Footballer.NotFound;

    }

    public async Task<ErrorOr<Created>> CreateFootballer(Footballer footballer)
    {
        await _footballersRepository.Create(footballer);

        return Result.Created;
    }

    public async Task<ErrorOr<Updated>> UpdateFootballer(Guid id, FootballerRequest request)
    {
       var updatedId = await _footballersRepository.Update(id, request);
       
       if (updatedId == null)
           return ErrorsService.Footballer.NotFound;
       
       return Result.Updated;
    }

    public async Task<ErrorOr<Deleted>> DeleteFootballer(Guid id)
    {
        /*var responseId = */
        await _footballersRepository.Delete(id);

        /*if (responseId == null)
            return ErrorsService.Footballer.NotFound;*/

        return Result.Deleted;
    }
}