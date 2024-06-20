namespace fithub_backend.NutritionManagement.Domain.Model.Commands;
public record UpdateNutritionCommand(int Id,
    string Name, string Description, string PhotoUrl, int ClassificationId);