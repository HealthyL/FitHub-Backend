using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Domain.Model.Entities;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.NutritionManagement.Domain.Services;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.NutritionManagement.Application.Internal.CommandServices;

public class ClassificationCommandService(IClassificationRepository 
        classificationRepository,
    IUnitOfWork unitOfWork) : IClassificationCommandService
{
    public async Task<Classification> Handle(CreateClassificationCommand command)
    {
        var classification = new Classification(command.Name);
        await classificationRepository.AddAsync(classification);
        await unitOfWork.CompleteAsync();
        return classification;
    }
}