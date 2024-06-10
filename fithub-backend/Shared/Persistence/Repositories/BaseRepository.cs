using BackEnd_FitHub.Shared.Persistence.Contexts;

namespace BackEnd_FitHub.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}