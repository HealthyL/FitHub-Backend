using fithub_backend.RutinesManagement.Domain.Model.Commands;
using fithub_backend.RutinesManagement.Interfaces.REST.Resources;

namespace fithub_backend.RutinesManagement.Interfaces.REST.Transform;

public class CreateRoutineCommandFromResourceAssembler
{
    public static CreateRoutineCommand ToCommandFromResource(CreateRoutineResource resource)
    {
        return new CreateRoutineCommand(resource.Name);
    }
}