using FootballerCatalog.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballerCatalog.DataBase;

public class FootballerDbContext : DbContext
{
    public FootballerDbContext(DbContextOptions<FootballerDbContext> options) : base(options)
    {
    }

    public DbSet<FootballerEntity> Footballers { get; set; }
}