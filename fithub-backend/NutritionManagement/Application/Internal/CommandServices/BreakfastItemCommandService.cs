using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.NutritionManagement.Domain.Services;
using fithub_backend.NutritionManagement.Infraestructure.Repositories;
using fithub_backend.Shared.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace fithub_backend.NutritionManagement.Application.Internal.CommandServices;

public class BreakfastItemCommandService(IBreakfastItemRepository breakfastItemRepository, 
    IUnitOfWork unitOfWork): IBreakfastItemCommandService
{
    /**Crear Breakfast Item*/
    public async Task<BreakfastItem?> Handle(CreateBreakfastItemCommand command)
    {
        var breakfastItem = await breakfastItemRepository.FindByNameAsync(command.Tittle);
        if (breakfastItem != null)
            throw new Exception("Breakfast Item with this name already exists");
        breakfastItem = new BreakfastItem(command);
        try
        {
            await breakfastItemRepository.AddAsync(breakfastItem);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return breakfastItem;
    }
    
    /**Eliminar Breakfast Item*/
    public async Task<BreakfastItem?> Handle(DeleteBreakfastItemCommand command)
    {
        var breakfastItem = await breakfastItemRepository.FindByIdAsync(command.Id);
        if (breakfastItem == null)
            throw new Exception("Breakfast Item not found");
        try
        {
            breakfastItemRepository.Remove(breakfastItem);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return breakfastItem;
    }
    
    /**Actualiza Breakfast Item*/
    public async Task<BreakfastItem?> Handle(UpdateBreakfastItemCommand command)
    {
        var breakfastItem = await breakfastItemRepository.FindByIdAsync(command.Id);
        if (breakfastItem == null)
            throw new Exception("Breakfast Item not found");
        breakfastItem.Update(command);
        try
        {
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return breakfastItem;
    }
    
}