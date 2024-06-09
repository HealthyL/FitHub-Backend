using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.NutritionManagement.Domain.Repositories;

public interface ILunchItemRepository: IBaseRepository<LunchItem>
{
    Task<LunchItem?> FindByNameAsync(String name);
    Task<IEnumerable<LunchItem>> GetAllAsync();
}