using fithub_backend.RutinesManagement.Domain.Model.Aggregates;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.RutinesManagement.Domain.Repositories;

public interface IExerciseRepository:IBaseRepository<Exercise>
{
    Task<bool> ExistsByRoutineIdAndExerciseNameAsync(int routineId, string exerciseName);
    Task<IEnumerable<Exercise>> FindByRoutineIdAsync(int routineId);
}