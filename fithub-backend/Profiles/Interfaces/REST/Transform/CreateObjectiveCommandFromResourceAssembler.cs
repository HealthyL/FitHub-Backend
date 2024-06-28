using fithub_backend.Profiles.Domain.Model.Commands;
using fithub_backend.Profiles.Interfaces.REST.Resources;

namespace fithub_backend.Profiles.Interfaces.REST.Transform;

public static class CreateObjectiveCommandFromResourceAssembler
{
    public static CreateObjectiveCommand ToCommandFromResource(CreateObjectiveResource resource)
    {
        return new CreateObjectiveCommand(resource.name);
    }
}