using FootballerCatalog.Contracts.Footballer;
using FootballerCatalog.Models;

namespace FootballerCatalog.Domain.Interfaces;

public interface IFootballersService
{
    Task<List<Footballer>> GetAllFootballers();
    Task<Guid> CreateFootballer(Footballer footballer);
    Task<Guid> UpdateFootballer(Guid id, FootballerRequest request);
    Task<Guid> DeleteFootballer(Guid id);
}