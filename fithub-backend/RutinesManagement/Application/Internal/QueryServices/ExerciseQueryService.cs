using fithub_backend.RutinesManagement.Domain.Model.Aggregates;
using fithub_backend.RutinesManagement.Domain.Model.Queries;
using fithub_backend.RutinesManagement.Domain.Repositories;
using fithub_backend.RutinesManagement.Domain.Services;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.RutinesManagement.Application.Internal.QueryService;

public class ExerciseQueryService(IExerciseRepository exerciseRepository, IUnitOfWork unitOfWork)
    :IExerciseQueryService
{
    public async Task<Exercise?> Handle(GetExerciseByIdQuery query)
    {
        return await exerciseRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Exercise>> Handle(GetAllExercisesQuery query)
    {
        return await exerciseRepository.ListAsync();
    }

    public async Task<IEnumerable<Exercise>> Handle(GetExerciseByRoutineIdQuery query)
    {
        return await exerciseRepository.FindByRoutineIdAsync(query.RoutineId);
    }
}