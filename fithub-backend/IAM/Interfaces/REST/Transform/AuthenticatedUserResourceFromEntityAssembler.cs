
using fithub_backend.IAM.Domain.Model.Aggregates;
using fithub_backend.IAM.Interfaces.REST.Resources;

namespace fithub_backend.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}