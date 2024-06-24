
using fithub_backend.IAM.Domain.Model.Commands;
using fithub_backend.IAM.Interfaces.REST.Resources;

namespace fithub_backend.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}