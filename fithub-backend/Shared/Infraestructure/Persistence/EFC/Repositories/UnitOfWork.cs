using fithub_backend.Shared.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;

namespace fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}