using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.ProductsManagement.Infraestructure.Repositories;

public class FunctionalProductsRepository: BaseRepository<FunctionalProduct>, IFunctionalProductRepository
{
    public FunctionalProductsRepository(AppDbContext context): base(context)
    {
    }
    public async Task<FunctionalProduct?> FindByNameAsync(string name)
    {
        return await Context.Set<FunctionalProduct>().Where(f => f.Name == name)
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<FunctionalProduct>> GetAllAsync()
    {
        return await Context.Set<FunctionalProduct>().ToListAsync();
    }
    public async Task<FunctionalProduct?> Handle(int id)
    {
        return await FindByIdAsync(id);
    }
}