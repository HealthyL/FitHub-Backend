using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Queries;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.NutritionManagement.Domain.Services;

namespace fithub_backend.NutritionManagement.Application.Internal.QueryServices;

public class DinnerItemQueryService(IDinnerItemRepository dinnerItemRepository)
    :IDinnerItemQueryService
{
    public async Task<DinnerItem?> Handle(GetDinnerItemByIdQuery query)
    {
        return await dinnerItemRepository.FindByIdAsync(query.Id);
    }
    public async Task<IEnumerable<DinnerItem>> Handle(GetAllDinnerItemsQuery query)
    {
        return await dinnerItemRepository.GetAllAsync();
    }
}