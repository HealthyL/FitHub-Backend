namespace fithub_backend.NutritionManagement.Interfaces.REST.Resources;

public record CreateLunchItemResource(String Tittle, String Description,
    String PhotoUrl, String Category)
{
}