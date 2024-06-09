using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class UpdateBreakfastItemCommandFromResourceAssembler
{
    public static UpdateBreakfastItemCommand ToCommandFromResource(UpdateBreakfastItemResource resource)
        => new UpdateBreakfastItemCommand(resource.Id, resource.Tittle, resource.Ingredients, resource.PhotoUrl, resource.Category);
}