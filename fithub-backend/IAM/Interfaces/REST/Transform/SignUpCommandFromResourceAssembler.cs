
using fithub_backend.IAM.Domain.Model.Commands;
using fithub_backend.IAM.Interfaces.REST.Resources;

namespace fithub_backend.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password, resource.Email, resource.BirthDate, resource.Objective);
    }
}