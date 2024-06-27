namespace fithub_backend.NutritionManagement.Interfaces.REST.Resources;

public record NutritionResource(
    int Id,
    string Name,
    string Description,
    string PhotoUrl,
    int ClassificationId);