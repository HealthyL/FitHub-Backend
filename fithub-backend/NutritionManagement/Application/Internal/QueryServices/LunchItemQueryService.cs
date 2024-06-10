using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Queries;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.NutritionManagement.Domain.Services;

namespace fithub_backend.NutritionManagement.Application.Internal.QueryServices;

public class LunchItemQueryService(ILunchItemRepository lunchItemRepository)
    : ILunchItemQueryService
{
    public async Task<LunchItem?> Handle(GetLunchItemByIdQuery query)
    {
        return await lunchItemRepository.FindByIdAsync(query.Id);
    }
    public async Task<IEnumerable<LunchItem>> Handle(GetAllLunchItemsQuery query)
    {
        return await lunchItemRepository.GetAllAsync();
    }
}