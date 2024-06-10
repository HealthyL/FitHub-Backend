using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.NutritionManagement.Domain.Services;
using fithub_backend.NutritionManagement.Infraestructure.Repositories;
using fithub_backend.Shared.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;

namespace fithub_backend.NutritionManagement.Application.Internal.CommandServices;

public class DinnerItemCommandService(IDinnerItemRepository dinnerItemRepository,
    IUnitOfWork unitOfWork):IDinnerItemCommandService
{
    /**Crear Dinner Item*/
    public async Task<DinnerItem?> Handle(CreateDinnerItemCommand command)
    {
        var dinnerItem = await dinnerItemRepository.FindByNameAsync(command.Tittle);
        if (dinnerItem != null)
            throw new Exception("Dinner Item with this name already exists");
        dinnerItem = new DinnerItem(command);
        try
        {
            await dinnerItemRepository.AddAsync(dinnerItem);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return dinnerItem;
    }
    
    /**Eliminar Dinner Item*/
    public async Task<DinnerItem?> Handle(DeleteDinnerItemCommand command)
    {
        var dinnerItem = await dinnerItemRepository.FindByIdAsync(command.Id);
        if (dinnerItem == null)
            throw new Exception("Dinner Item not found");
        try
        {
            dinnerItemRepository.Remove(dinnerItem);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return dinnerItem;
    }
    
    /**Actualiza Dinner Item*/
    public async Task<DinnerItem?> Handle(UpdateDinnerItemCommand command)
    {
        var dinnerItem = await dinnerItemRepository.FindByIdAsync(command.Id);
        if (dinnerItem == null)
            throw new Exception("Dinner Item not found");
        dinnerItem.Update(command);
        try
        {
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return dinnerItem;
    }
}