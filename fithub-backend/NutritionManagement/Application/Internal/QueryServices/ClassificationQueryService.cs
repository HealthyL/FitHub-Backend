using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Entities;
using fithub_backend.NutritionManagement.Domain.Model.Queries;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.NutritionManagement.Domain.Services;

namespace fithub_backend.NutritionManagement.Application.Internal.QueryServices;

public class ClassificationQueryService(IClassificationRepository classificationRepository)
    : IClassificationQueryService
{
    public async Task<IEnumerable<Classification>> Handle(GetAllClassificationsQuery query)
    {
        return await classificationRepository.ListAsync();
    }
}