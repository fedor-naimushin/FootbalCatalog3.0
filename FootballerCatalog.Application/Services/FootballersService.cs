using FootballerCatalog.Domain.Interfaces;
using FootballerCatalog.Models;

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

    public async Task<Guid> CreateFootballer(Footballer footballer)
    {
        return await _footballersRepository.Create(footballer);
    }

    public async Task<Guid> UpdateFootballer(Footballer footballer)
    {
        return await _footballersRepository.Update(footballer);
    }

    public async Task<Guid> DeleteFootballer(Guid id)
    {
        return await _footballersRepository.Delete(id);
    }
}