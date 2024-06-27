namespace fithub_backend.NutritionManagement.Interfaces.REST.Resources;

public record CreateNutritionResource(
    string Name, 
    string Description,
    string PhotoUrl,
    int ClassificationId);