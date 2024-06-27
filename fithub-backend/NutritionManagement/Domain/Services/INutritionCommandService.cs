using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Commands;

namespace fithub_backend.NutritionManagement.Domain.Services;

public interface INutritionCommandService
{
    Task<Nutrition?> Handle(CreateNutritionCommand command);
    Task<Nutrition?> Handle(UpdateNutritionCommand command);
    Task<Nutrition?> Handle(DeleteNutritionCommand command);
}