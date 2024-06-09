namespace fithub_backend.NutritionManagement.Domain.Model.Commands;
public record CreateDinnerItemCommand(String Tittle, String Ingredients, String PhotoUrl, String Category)
{
}