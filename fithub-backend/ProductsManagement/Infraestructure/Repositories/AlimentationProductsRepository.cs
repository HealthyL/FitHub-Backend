using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.ProductsManagement.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.ProductsManagement.Infraestructure.Repositories;

public class AlimentationProductsRepository : BaseRepository<AlimentationProduct>, IAlimentationProductRepository 
{
    public AlimentationProductsRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<AlimentationProduct?> FindByNameAsync(string name)
    {
        return await Context.Set<AlimentationProduct>().Where(f => f.Name == name)
            .FirstOrDefaultAsync();    
    }
    public async Task<IEnumerable<AlimentationProduct>> GetAllAsync()
    {
        return await Context.Set<AlimentationProduct>().ToListAsync();
    }

    public async Task<AlimentationProduct?> Handle(int id)
    {
        return await FindByIdAsync(id);
    }
}