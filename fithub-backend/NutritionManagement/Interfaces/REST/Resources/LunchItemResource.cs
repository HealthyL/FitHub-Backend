namespace fithub_backend.NutritionManagement.Interfaces.REST.Resources;

public record LunchItemResource
    (int Id, String Tittle, String Description,
        String PhotoUrl, String Category)
{
}