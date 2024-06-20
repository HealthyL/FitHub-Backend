using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class UpdateNutritionCommandFromResourceAssembler
{
    public static UpdateNutritionCommand ToCommandFromResource(UpdateNutritionResource resource)
    {
        return new UpdateNutritionCommand(resource.Id, resource.Name, resource.Description, resource.PhotoUrl, resource.ClassificationId);
    }
}