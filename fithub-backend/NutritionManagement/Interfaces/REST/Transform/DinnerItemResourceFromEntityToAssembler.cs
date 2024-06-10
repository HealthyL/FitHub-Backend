using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class DinnerItemResourceFromEntityToAssembler
{
    public static DinnerItemResource ToResourceFromEntity(DinnerItem entity)
        => new DinnerItemResource(entity.Id, entity.Tittle, entity.Ingredients, entity.PhotoUrl, entity.Category);
}