using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Queries;

namespace fithub_backend.NutritionManagement.Domain.Services;

public interface IDinnerItemQueryService
{
    Task<IEnumerable<DinnerItem>> Handle(GetAllDinnerItemsQuery query);
}