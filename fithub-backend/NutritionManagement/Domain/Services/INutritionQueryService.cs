using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Queries;

namespace fithub_backend.NutritionManagement.Domain.Services;

public interface INutritionQueryService
{
    Task<IEnumerable<Nutrition>> Handle(GetAllNutritionsQuery query);
    Task<IEnumerable<Nutrition>> Handle(GetNutritionByClassificationIdQuery query);

}