using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.Profiles.Domain.Model;
using fithub_backend.Profiles.Domain.Model.Commands;
using fithub_backend.Profiles.Domain.Repositories;
using fithub_backend.Profiles.Domain.Services;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.Profiles.Application.Internal.CommandService;

public class ObjectiveCommandService(IObjectiveRepository objectiveRepository, 
    IUnitOfWork unitOfWork) : IObjectiveCommandService
{
    public async Task<Objective?> Handle(CreateObjectiveCommand command)
    {
        var existsByName = await objectiveRepository.ExistsByNameAsync(command.name);
        if (existsByName) throw new Exception("Category with the same name already exists");

        var objective = new Objective(command.name);
        await objectiveRepository.AddAsync(objective);
        await unitOfWork.CompleteAsync();
        return objective;
    }    
}
