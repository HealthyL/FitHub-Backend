using fithub_backend.RutinesManagement.Domain.Model.Commands;
using fithub_backend.RutinesManagement.Interfaces.REST.Resources;

namespace fithub_backend.RutinesManagement.Interfaces.REST.Transform;

public class CreateExerciseCommandFromResourceAssembler
{
    public static CreateExerciseCommand ToCommandFromResource(CreateExerciseResource resource)
    {
        return new CreateExerciseCommand(resource.Name, resource.PhotoUrl, resource.Sets, resource.Reps, resource.Weight, resource.RoutineId);
    }
}