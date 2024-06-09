using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.NutritionManagement.Domain.Repositories;

public interface IBreakfastItemRepository: IBaseRepository<BreakfastItem>
{
    Task<BreakfastItem?> FindByNameAsync(String name);
    Task<IEnumerable<BreakfastItem>> GetAllAsync();
}