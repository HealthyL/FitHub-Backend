using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
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
    public async Task<AlimentationProduct?> FindByAlimentationProductIdAsync(int productId)
    {
        return await Context.Set<AlimentationProduct>().FirstOrDefaultAsync(f => f.Id == productId);
    }
}