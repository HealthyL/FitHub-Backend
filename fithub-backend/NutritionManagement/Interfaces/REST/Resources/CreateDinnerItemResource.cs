namespace fithub_backend.NutritionManagement.Interfaces.REST.Resources;

public record CreateDinnerItemResource(String Tittle, String Ingredients,
    String PhotoUrl, String Category)
{
}