using fithub_backend.RutinesManagement.Domain.Model.Aggregates;
using fithub_backend.RutinesManagement.Domain.Model.Queries;

namespace fithub_backend.RutinesManagement.Domain.Services;

public interface IExerciseQueryService
{
    Task<Exercise?> Handle(GetExerciseByIdQuery query);
    Task<IEnumerable<Exercise>> Handle(GetAllExercisesQuery query);
    Task<IEnumerable<Exercise>> Handle(GetExerciseByRoutineIdQuery query);

}