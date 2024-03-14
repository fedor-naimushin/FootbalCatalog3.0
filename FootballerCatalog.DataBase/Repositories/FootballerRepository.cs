using FootballerCatalog.Models;

namespace FootballerCatalog.DataBase.Repositories;

public class FootballerRepository
{
    private readonly FootballerDbContext _context;

    public FootballerRepository(FootballerDbContext context)
    {
        _context = context;
    }

    /*public async Task<List<Footballer>> Create()
    {
        return 
    }*/
}