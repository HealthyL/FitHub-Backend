using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class CreateLunchItemCommandFromResourceAssembler
{
    public static CreateLunchItemCommand ToCommandFromResource(CreateLunchItemResource resource)
        => new CreateLunchItemCommand(resource.Tittle, resource.Description, resource.PhotoUrl, resource.Category);
}