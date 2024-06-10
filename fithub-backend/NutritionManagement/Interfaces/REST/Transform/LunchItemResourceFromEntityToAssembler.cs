using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class LunchItemResourceFromEntityToAssembler
{
    public static LunchItemResource ToResourceFromEntity(LunchItem entity)
        => new LunchItemResource(entity.Id, entity.Tittle, entity.Description, entity.PhotoUrl, entity.Category);
}