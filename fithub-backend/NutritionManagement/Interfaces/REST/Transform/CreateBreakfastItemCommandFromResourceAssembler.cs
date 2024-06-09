using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class CreateBreakfastItemCommandFromResourceAssembler
{
    public static CreateBreakfastItemCommand ToCommandFromResource(CreateBreakfastItemResource resource)
        => new CreateBreakfastItemCommand(resource.Tittle, resource.Ingredients, resource.PhotoUrl, resource.Category);
}