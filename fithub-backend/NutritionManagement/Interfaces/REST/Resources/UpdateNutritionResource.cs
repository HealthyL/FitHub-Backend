namespace fithub_backend.NutritionManagement.Interfaces.REST.Resources;

public record UpdateNutritionResource(
    int Id,
    string Name, 
    string Description,
    string PhotoUrl,
    int ClassificationId);