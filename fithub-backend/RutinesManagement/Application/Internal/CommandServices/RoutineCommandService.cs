using fithub_backend.RutinesManagement.Domain.Model.Commands;
using fithub_backend.RutinesManagement.Domain.Model.Entities;
using fithub_backend.RutinesManagement.Domain.Repositories;
using fithub_backend.RutinesManagement.Domain.Services;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.RutinesManagement.Application.Internal.CommandService;

public class RoutineCommandService(IRoutineRepository routineRepository,
    IUnitOfWork unitOfWork): IRoutineCommandService
{
    public async Task<Routine> Handle(CreateRoutineCommand command)
    {
        var existsByName = await routineRepository.ExistsByNameAsync(command.Name);
        if (existsByName) throw new Exception("Routine with the same name already exists");
        var routine = new Routine(command.Name);
        await routineRepository.AddAsync(routine);
        await unitOfWork.CompleteAsync();
        return routine;
    }
}