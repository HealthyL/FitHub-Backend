using fithub_backend.Profiles.Domain.Model;
using fithub_backend.Profiles.Interfaces.REST.Resources;

namespace fithub_backend.Profiles.Interfaces.REST.Transform;

public static class ObjectiveResourceFromEntityAssembler
{
    public static ObjectiveResource ToResourceFromEntity(Objective entity)
    {
        return new ObjectiveResource(entity.Id, entity.Name);
    }
}