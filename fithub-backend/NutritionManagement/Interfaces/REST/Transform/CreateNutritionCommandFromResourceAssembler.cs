using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class CreateNutritionCommandFromResourceAssembler
{
    public static CreateNutritionCommand ToCommandFromResource(CreateNutritionResource resource)
    {
        return new CreateNutritionCommand(resource.Name, resource.Description, resource.PhotoUrl, resource.ClassificationId);
    }
}