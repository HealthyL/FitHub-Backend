﻿namespace fithub_backend.NutritionManagement.Domain.Model.Commands;

public record CreateNutritionCommand(string Name,
    string Description, string PhotoUrl, int ClassificationId);