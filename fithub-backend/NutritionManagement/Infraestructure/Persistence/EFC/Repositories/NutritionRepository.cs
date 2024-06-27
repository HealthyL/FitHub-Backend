using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.NutritionManagement.Infraestructure.Persistence.EFC.Repositories;

public class NutritionRepository(AppDBContext context) : 
    BaseRepository<Nutrition>(context), INutritionRepository
{
    public async Task<bool> ExistsByClassificationIdAndNutritionNameAsync(int classificationId, string nutritionName)
    {
        return await Context.Set<Nutrition>()
            .AnyAsync(nutrition => nutrition.ClassificationId 
                == classificationId && nutrition.Name == nutritionName);
    }

    public async Task<IEnumerable<Nutrition>>
        FindByClassificationIdAsync(int classificationId)
    {
        return await Context.Set<Nutrition>()
            .Where(nutrition => nutrition.ClassificationId == classificationId)
            .ToListAsync();
    }
    
}