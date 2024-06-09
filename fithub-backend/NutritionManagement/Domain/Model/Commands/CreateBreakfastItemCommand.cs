namespace fithub_backend.NutritionManagement.Domain.Model.Commands;
public record CreateBreakfastItemCommand(String Tittle, String Ingredients, String PhotoUrl, String Category)
{
}