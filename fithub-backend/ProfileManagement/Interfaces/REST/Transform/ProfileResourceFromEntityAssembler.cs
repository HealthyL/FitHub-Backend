using fithub_backend.ProfileManagement.Domain.Model.Aggregates;
using fithub_backend.ProfileManagement.Interfaces.REST.Resources;

namespace fithub_backend.ProfileManagement.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.FullName, entity.EmailAddress, entity.ProfileAddress);
    }
}