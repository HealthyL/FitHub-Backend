using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class BreakfastItemResourceFromEntityToAssembler
{
    public static BreakfastItemResource ToResourceFromEntity(BreakfastItem entity)
    => new BreakfastItemResource(entity.Id, entity.Tittle, entity.Ingredients, entity.PhotoUrl, entity.Category);
}