using FootballerCatalog.Contracts.Footballer;
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

    public async Task<Footballer?> GeById(Guid id)
    {
        var entity = await _context.Footballers
            .FindAsync(id);

        if (entity == null)
            return null;
        
        return new Footballer(
            entity.Id,
            entity.FirstName,
            entity.LastName,
            entity.Gender,
            entity.Birthday,
            entity.TeamTitle,
            entity.Country
        );
    }

    public async Task<Guid> Create(Footballer footballer)
    {
        var footballerEntity = new FootballerEntity
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

    public async Task<Guid?> Update(Guid id, FootballerRequest request)
    {
        var entity = await _context.Footballers.FindAsync(id);

        if (entity == null)
        {
            return null;
        }
        
        await _context.Footballers
            .Where(f => f.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(f => f.FirstName, f => request.FirstName)
                .SetProperty(f => f.LastName, f => request.LastName)
                .SetProperty(f => f.Gender, f => request.Gender)
                .SetProperty(f => f.Birthday, f => request.Birthday)
                .SetProperty(f => f.TeamTitle, f => request.TeamTitle)
                .SetProperty(f => f.Country, f => request.Country));

        return id;
    }

    public async Task<Guid?> Delete(Guid id)
    {
        var entity = await _context.Footballers.FindAsync(id);

        if (entity == null)
            return null;
        
        await _context.Footballers
            .Where(f => f.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}