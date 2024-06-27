using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class CreateClassificationCommandFromResourceAssembler
{
    public static CreateClassificationCommand toCommandFromResource(CreateClassificationResource resource)
    {
        return new CreateClassificationCommand(resource.Name);
    }
}