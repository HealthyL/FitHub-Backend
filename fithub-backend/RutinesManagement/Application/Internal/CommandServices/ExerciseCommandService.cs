using fithub_backend.RutinesManagement.Domain.Model.Aggregates;
using fithub_backend.RutinesManagement.Domain.Model.Commands;
using fithub_backend.RutinesManagement.Domain.Repositories;
using fithub_backend.RutinesManagement.Domain.Services;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.RutinesManagement.Application.Internal.CommandService;

public class ExerciseCommandService(IExerciseRepository exerciseRepository, IRoutineRepository routineRepository,
    IUnitOfWork unitOfWork): IExerciseCommandService
{
    public async Task<Exercise?> Handle(CreateExerciseCommand command)
    {
        if(command.Reps <= 0) throw new Exception("Reps must be greater than 0");
        if(command.Sets <= 0) throw new Exception("Sets must be greater than 0");
        var routineExists = await routineRepository.ExistsByIdAsync(command.RoutineId);
        if (!routineExists) throw new Exception("Routine Id does not exist");

        var existsByName = await exerciseRepository.ExistsByRoutineIdAndExerciseNameAsync(command.RoutineId,command.Name);
        if (existsByName) throw new Exception("Exercise with the same name already exists");
        var exercise = new Exercise(command.Name, command.PhotoUrl, command.Sets, command.Reps, command.Weight,
            command.RoutineId);
        await exerciseRepository.AddAsync(exercise);
        await unitOfWork.CompleteAsync();
        return exercise;
    }
}