using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.NutritionManagement.Infraestructure.Repositories;

public class BreakfastItemsRepository : BaseRepository<BreakfastItem>, IBreakfastItemRepository
{
    public BreakfastItemsRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<BreakfastItem?> FindByNameAsync(string name)
    {
        return await Context.Set<BreakfastItem>().Where(f => f.Tittle == name)
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<BreakfastItem>> GetAllAsync()
    {
        return await Context.Set<BreakfastItem>().ToListAsync();
    }

    public async Task<BreakfastItem?> Handle(int id)
    {
        return await FindByIdAsync(id);
    }
}