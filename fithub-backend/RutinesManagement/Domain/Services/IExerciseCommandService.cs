using fithub_backend.RutinesManagement.Domain.Model.Aggregates;
using fithub_backend.RutinesManagement.Domain.Model.Commands;

namespace fithub_backend.RutinesManagement.Domain.Services;

public interface IExerciseCommandService
{
    Task<Exercise?> Handle(CreateExerciseCommand command);

}