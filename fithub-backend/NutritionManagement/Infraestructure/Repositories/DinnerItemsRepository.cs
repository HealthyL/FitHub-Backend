using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.NutritionManagement.Infraestructure.Repositories;

public class DinnerItemsRepository: BaseRepository<DinnerItem>, IDinnerItemRepository
{
    public DinnerItemsRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<DinnerItem?> FindByNameAsync(string name)
    {
        return await Context.Set<DinnerItem>().Where(f => f.Tittle == name)
            .FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<DinnerItem>> GetAllAsync()
    {
        return await Context.Set<DinnerItem>().ToListAsync();
    }
    
    public async Task<DinnerItem?> Handle(int id)
    {
        return await FindByIdAsync(id);
    }
}