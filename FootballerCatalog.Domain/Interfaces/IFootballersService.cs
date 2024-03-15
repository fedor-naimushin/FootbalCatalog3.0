using FootballerCatalog.Contracts.Footballer;
using FootballerCatalog.Models;
using ErrorOr;

namespace FootballerCatalog.Domain.Interfaces;

public interface IFootballersService
{
    Task<List<Footballer>> GetAllFootballers();
    Task<ErrorOr<Footballer>> GetById(Guid id);
    Task<ErrorOr<Created>> CreateFootballer(Footballer footballer);
    Task<ErrorOr<Updated>> UpdateFootballer(Guid id, FootballerRequest request);
    Task<ErrorOr<Deleted>> DeleteFootballer(Guid id);
}