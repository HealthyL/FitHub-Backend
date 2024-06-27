using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Queries;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.NutritionManagement.Domain.Services;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.NutritionManagement.Application.Internal.QueryServices;

public class NutritionQueryService(INutritionRepository nutritionRepository, IUnitOfWork unitOfWork): INutritionQueryService
{
    public async Task<IEnumerable<Nutrition>> Handle(GetAllNutritionsQuery query)
    {
        return await nutritionRepository.ListAsync();
    }
    
    public async Task<IEnumerable<Nutrition>> Handle(GetNutritionByClassificationIdQuery query)
    {
        return await nutritionRepository.FindByClassificationIdAsync(query.ClassificationId);
    }
}