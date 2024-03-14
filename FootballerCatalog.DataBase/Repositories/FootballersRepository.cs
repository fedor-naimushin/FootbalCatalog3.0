using FootballerCatalog.DataBase.Entities;
using FootballerCatalog.Domain.Interfaces;
using FootballerCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballerCatalog.DataBase.Repositories;

public class FootballersRepository : IFootballersRepository
{
    private readonly FootballerDbContext _context;

    public FootballersRepository(FootballerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Footballer>> GetAll()
    {
        var footballerEntities = await _context.Footballers
            .AsNoTracking()
            .ToListAsync();

        var footballers = footballerEntities
            .Select(f => new Footballer(
                f.Id,
                f.FirstName,
                f.LastName,
                f.Gender,
                f.Birthday,
                f.TeamTitle,
                f.Country
            ))
            .ToList();

        return footballers;
    }

    public async Task<Guid> Create(Footballer footballer)
    {
        var footballerEntity = new FootballerEntity()
        {
            Id = footballer.Id,
            FirstName = footballer.FirstName,
            LastName = footballer.LastName,
            Gender = footballer.Gender,
            Birthday = footballer.Birthday,
            TeamTitle = footballer.TeamTitle,
            Country = footballer.Country
        };

        await _context.Footballers.AddAsync(footballerEntity);
        await _context.SaveChangesAsync();

        return footballerEntity.Id;
    }

    public async Task<Guid> Update(Footballer footballer)
    {
        await _context.Footballers
            .Where(f => f.Id == footballer.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(f => f.FirstName, f => footballer.FirstName)
                .SetProperty(f => f.LastName, f => footballer.LastName)
                .SetProperty(f => f.Gender, f => footballer.Gender)
                .SetProperty(f => f.Birthday, f => footballer.Birthday)
                .SetProperty(f => f.TeamTitle, f => footballer.TeamTitle)
                .SetProperty(f => f.Country, f => footballer.Country));

        return footballer.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Footballers
            .Where(f => f.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}