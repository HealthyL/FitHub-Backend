using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.NutritionManagement.Domain.Repositories;

public interface INutritionRepository: IBaseRepository<Nutrition>
{
    //No pueden existir dos nutriciones con el mismo nombre en la misma categoria
    Task<bool> ExistsByClassificationIdAndNutritionNameAsync(int classificationId, string nutritionName); 
    Task<IEnumerable<Nutrition>> FindByClassificationIdAsync(int classificationId);
}