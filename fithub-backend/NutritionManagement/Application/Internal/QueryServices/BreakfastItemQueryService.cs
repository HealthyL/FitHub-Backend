using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Queries;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.NutritionManagement.Domain.Services;

namespace fithub_backend.NutritionManagement.Application.Internal.QueryServices;

public class BreakfastItemQueryService(IBreakfastItemRepository breakfastItemRepository)
    : IBreakfastItemQueryService
{
    public async Task<BreakfastItem?> Handle(GetBreakfastItemByIdQuery query)
    {
        return await breakfastItemRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<BreakfastItem>> Handle(GetAllBreakfastItemsQuery query)
    {
        return await breakfastItemRepository.GetAllAsync();
    }
}