using fithub_backend.RutinesManagement.Domain.Model.Aggregates;
using fithub_backend.RutinesManagement.Interfaces.REST.Resources;

namespace fithub_backend.RutinesManagement.Interfaces.REST.Transform;

public class ExerciseResourceFromEntityAssembler
{
    public static ExerciseResource ToResourceFromEntity(Exercise entity)
    {
        return new ExerciseResource(entity.Id, entity.Name, entity.PhotoUrl, entity.Sets, entity.Reps, entity.Weight, entity.RoutineId);
    }
}