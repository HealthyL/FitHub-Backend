using fithub_backend.RutinesManagement.Domain.Model.Entities;
using fithub_backend.RutinesManagement.Interfaces.REST.Resources;

namespace fithub_backend.RutinesManagement.Interfaces.REST.Transform;

public class RoutineResourceFromEntityAssembler
{
    public static RoutineResource ToResourceFromEntity(Routine entity)
    {
        return new RoutineResource(entity.Id, entity.Name);
    }
}