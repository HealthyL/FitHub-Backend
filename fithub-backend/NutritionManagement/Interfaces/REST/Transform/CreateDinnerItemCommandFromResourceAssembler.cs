using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class CreateDinnerItemCommandFromResourceAssembler
{
    public static CreateDinnerItemCommand ToCommandFromResource(CreateDinnerItemResource resource)
        => new CreateDinnerItemCommand(resource.Tittle, resource.Ingredients, resource.PhotoUrl, resource.Category);
}