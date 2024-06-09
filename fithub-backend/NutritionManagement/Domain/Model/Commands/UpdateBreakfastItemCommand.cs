namespace fithub_backend.NutritionManagement.Domain.Model.Commands;

public record UpdateBreakfastItemCommand(int Id,String Tittle, String Ingredients, String PhotoUrl, String Category)
{
    
}