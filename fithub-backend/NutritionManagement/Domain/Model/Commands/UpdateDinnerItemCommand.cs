namespace fithub_backend.NutritionManagement.Domain.Model.Commands;
public record UpdateDinnerItemCommand(int Id,String Tittle, String Ingredients, String PhotoUrl, String Category)
{
}