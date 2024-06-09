namespace fithub_backend.NutritionManagement.Interfaces.REST.Resources;

public record UpdateBreakfastItemResource
(int Id,String Tittle, String Ingredients,
    String PhotoUrl, String Category)
{
}