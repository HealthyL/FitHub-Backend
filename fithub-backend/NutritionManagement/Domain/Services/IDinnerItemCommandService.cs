using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Commands;

namespace fithub_backend.NutritionManagement.Domain.Services;

public interface IDinnerItemCommandService
{
    Task<DinnerItem?> Handle(CreateDinnerItemCommand command);
    Task<DinnerItem?> Handle(UpdateDinnerItemCommand command);
    Task<DinnerItem?> Handle(DeleteDinnerItemCommand command);
}