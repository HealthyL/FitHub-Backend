using fithub_backend.NutritionManagement.Domain.Model.Aggregates;
using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.NutritionManagement.Domain.Services;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.NutritionManagement.Application.Internal.CommandServices;

public class NutritionCommandService(INutritionRepository nutritionRepository,
    IClassificationRepository classificationRepository, IUnitOfWork unitOfWork)
    : INutritionCommandService
{
    public async Task<Nutrition?> Handle(CreateNutritionCommand command)
    {
        var classificationExists = await classificationRepository.ExistsByIdAsync(command.ClassificationId);
        if (!classificationExists) throw new Exception("Classification Id does not exist");

        var existsByClassificationIdAndNutritionName =
            await nutritionRepository.ExistsByClassificationIdAndNutritionNameAsync(command.ClassificationId,
                command.Name);
        if (existsByClassificationIdAndNutritionName)
            throw new Exception("Nutrition with the same Classification Id and Nutrition Name already exists");

        var nutrition = new Nutrition(command.Name, command.Description, command.PhotoUrl, command.ClassificationId);
        await nutritionRepository.AddAsync(nutrition);
        await unitOfWork.CompleteAsync();
        return nutrition;
    }
    
    public async Task<Nutrition?> Handle(DeleteNutritionCommand command)
    {
        var nutrition = await nutritionRepository.FindByIdAsync(command.Id);
        if (nutrition == null) throw new Exception("Nutrition not found");
        try
        {
            nutritionRepository.Remove(nutrition);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return nutrition;
    }
    
    public async Task<Nutrition?> Handle(UpdateNutritionCommand command)
    {
        var nutrition = await nutritionRepository.FindByIdAsync(command.Id);
        if (nutrition == null) throw new Exception("Nutrition not found");
        nutrition.Update(command);
        try
        {
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return nutrition;
    }
}