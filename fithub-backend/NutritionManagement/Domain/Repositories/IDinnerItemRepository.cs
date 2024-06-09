using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.NutritionManagement.Domain.Repositories;

public interface IDinnerItemRepository: IBaseRepository<DinnerItem>
{
    Task<DinnerItem?> FindByNameAsync(String name);
    Task<IEnumerable<DinnerItem>> GetAllAsync();
}