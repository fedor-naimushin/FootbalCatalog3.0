using FootballerCatalog.Models;

namespace FootballerCatalog.Application.Services;

public interface IFootballersService
{
    Task<List<Footballer>> GetAllFootballers();
    Task<Guid> CreateFootballer(Footballer footballer);
    Task<Guid> UpdateFootballer(Footballer footballer);
    Task<Guid> DeleteFootballer(Guid id);
}