using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class UpdateDinnerItemCommandFromResourceAssembler
{
    public static UpdateDinnerItemCommand ToCommandFromResource(UpdateDinnerItemResource resource)
        => new UpdateDinnerItemCommand(resource.Id, resource.Tittle, resource.Ingredients, resource.PhotoUrl, resource.Category);
}