using fithub_backend.RutinesManagement.Domain.Model.Aggregates;
using fithub_backend.RutinesManagement.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.RutinesManagement.Infraestructure.Persistence.EFC.Repositories;

public class ExerciseRepository(AppDBContext context):BaseRepository<Exercise>(context), 
    IExerciseRepository
{
    public async Task<bool> ExistsByRoutineIdAndExerciseNameAsync(int routineId, string exerciseName)
    {
        return await Context.Set<Exercise>()
            .AnyAsync(exercise=>exercise.RoutineId==routineId && exercise.Name==exerciseName);
    }

    public async Task<IEnumerable<Exercise>> FindByRoutineIdAsync(int routineId)
    {
        return await Context.Set<Exercise>()
            .Where(exercise => exercise.RoutineId == routineId)
            .ToListAsync();
    }
}