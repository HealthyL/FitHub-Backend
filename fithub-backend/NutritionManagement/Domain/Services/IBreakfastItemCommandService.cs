using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Commands;

namespace fithub_backend.NutritionManagement.Domain.Services;

public interface IBreakfastItemCommandService
{
    Task<BreakfastItem?> Handle(CreateBreakfastItemCommand command);
    Task<BreakfastItem?> Handle(UpdateBreakfastItemCommand command);
    Task<BreakfastItem?> Handle(DeleteBreakfastItemCommand command);
}