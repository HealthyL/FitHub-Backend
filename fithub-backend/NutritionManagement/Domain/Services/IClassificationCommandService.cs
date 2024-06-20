using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Domain.Model.Entities;

namespace fithub_backend.NutritionManagement.Domain.Services;

public interface IClassificationCommandService
{
    public Task<Classification> Handle(CreateClassificationCommand command);
}