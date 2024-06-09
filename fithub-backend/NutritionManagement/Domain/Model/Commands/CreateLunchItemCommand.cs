namespace fithub_backend.NutritionManagement.Domain.Model.Commands;
public record CreateLunchItemCommand(String Tittle, String Description, String PhotoUrl, String Category)
{
}