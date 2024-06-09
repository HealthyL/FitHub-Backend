using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Queries;

namespace fithub_backend.NutritionManagement.Domain.Services;

public interface IBreakfastItemQueryService
{
    Task<BreakfastItem?> Handle(GetBreakfastItemByIdQuery query);
    Task<IEnumerable<BreakfastItem>> Handle(GetAllBreakfastItemsQuery query);
}