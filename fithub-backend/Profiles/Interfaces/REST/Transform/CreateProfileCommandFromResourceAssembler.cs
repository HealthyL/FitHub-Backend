using fithub_backend.Profiles.Domain.Model.Commands;
using fithub_backend.Profiles.Interfaces.REST.Resources;

namespace fithub_backend.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.FullName, resource.Email, resource.BirthDate, resource.Objective);
    }
}