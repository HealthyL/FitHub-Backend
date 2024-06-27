using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Entities;
using fithub_backend.NutritionManagement.Domain.Model.Queries;

namespace fithub_backend.NutritionManagement.Domain.Services;

public interface IClassificationQueryService
{
    Task<IEnumerable<Classification>> Handle(GetAllClassificationsQuery query);
}