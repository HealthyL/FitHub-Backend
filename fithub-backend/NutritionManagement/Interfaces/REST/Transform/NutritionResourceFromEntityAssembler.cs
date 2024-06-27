using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class NutritionResourceFromEntityAssembler
{
    public static NutritionResource toResourceFromEntity(Nutrition entity)
    {
        return new NutritionResource(
            entity.Id, entity.Name,
            entity.Description,entity.Description,
            entity.ClassificationId);
    }
}