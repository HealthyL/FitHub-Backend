using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Queries;

namespace fithub_backend.NutritionManagement.Domain.Services;

public interface ILunchItemQueryService
{
    Task<LunchItem?> Handle(GetLunchItemByIdQuery query);
    Task<IEnumerable<LunchItem>> Handle(GetAllLunchItemsQuery query);
}