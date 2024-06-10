using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.NutritionManagement.Domain.Services;
using fithub_backend.NutritionManagement.Infraestructure.Repositories;
using fithub_backend.Shared.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace fithub_backend.NutritionManagement.Application.Internal.CommandServices;

public class LunchItemCommandService(ILunchItemRepository lunchItemRepository,
    IUnitOfWork unitOfWork):ILunchItemCommandService
{
    /**Crear Lunch Item*/
    public async Task<LunchItem?> Handle(CreateLunchItemCommand command)
    {
        var lunchItem = await lunchItemRepository.FindByNameAsync(command.Tittle);
        if (lunchItem != null)
            throw new Exception("Lunch Item with this name already exists");
        lunchItem = new LunchItem(command);
        try
        {
            await lunchItemRepository.AddAsync(lunchItem);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return lunchItem;
    }
}