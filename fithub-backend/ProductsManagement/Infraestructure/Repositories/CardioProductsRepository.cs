using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.ProductsManagement.Infraestructure.Repositories;

public class CardioProductsRepository:BaseRepository<CardioProduct>, ICardioProductRepository
{
    public CardioProductsRepository(AppDbContext context): base(context)
    {
    }
    public async Task<CardioProduct?> FindByNameAsync(string name)
    {
        return await Context.Set<CardioProduct>().Where(f => f.Name == name)
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<CardioProduct>> GetAllAsync()
    {
        return await Context.Set<CardioProduct>().ToListAsync();
    }
    public async Task<CardioProduct?> Handle(int id)
    {
        return await FindByIdAsync(id);
    }
}