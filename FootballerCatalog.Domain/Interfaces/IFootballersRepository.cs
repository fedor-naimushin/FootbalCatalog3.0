using FootballerCatalog.Contracts.Footballer;
using FootballerCatalog.Models;
using ErrorOr;

namespace FootballerCatalog.Domain.Interfaces;

public interface IFootballersRepository
{
    Task<List<Footballer>> GetAll();
    Task<Footballer?> GeById(Guid id);
    Task<Guid> Create(Footballer footballer);
    Task<Guid?> Update(Guid id, FootballerRequest request);
    Task<Guid?> Delete(Guid id);
}