using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.NutritionManagement.Infraestructure.Repositories;

public class LunchItemsRepository: BaseRepository<LunchItem>, ILunchItemRepository
{
    public LunchItemsRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<LunchItem?> FindByNameAsync(string name)
    {
        return await Context.Set<LunchItem>().Where(f => f.Tittle == name)
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<LunchItem>> GetAllAsync()
    {
        return await Context.Set<LunchItem>().ToListAsync();
    }
    public async Task<LunchItem?> Handle(int id)
    {
        return await FindByIdAsync(id);
    }
}