namespace fithub_backend.NutritionManagement.Interfaces.REST.Resources;

public record CreateBreakfastItemResource(String Tittle, String Ingredients,
    String PhotoUrl, String Category)
{
}