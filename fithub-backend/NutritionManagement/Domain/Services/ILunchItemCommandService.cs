using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Commands;

namespace fithub_backend.NutritionManagement.Domain.Services;

public interface ILunchItemCommandService
{
    Task<LunchItem?> Handle(CreateLunchItemCommand command);
}