using FootballerCatalog.Contracts.Footballer;
using FootballerCatalog.Models;

namespace FootballerCatalog.Domain.Interfaces;

public interface IFootballersRepository
{
    Task<List<Footballer>> GetAll();
    Task<Guid> Create(Footballer footballer);
    Task<Guid> Update(Guid id, FootballerRequest request);
    Task<Guid> Delete(Guid id);
}