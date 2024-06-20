using fithub_backend.NutritionManagement.Domain.Model.Entities;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;

namespace fithub_backend.NutritionManagement.Interfaces.REST.Transform;

public class ClassificationResourceFromEntityAssembler
{
    public static ClassificationResource toResourceFromEntity(Classification entity)
    {
        return new ClassificationResource(entity.Id, entity.Name);
    }
}