﻿namespace fithub_backend.NutritionManagement.Interfaces.REST.Resources;

public record DinnerItemResource
(int Id, String Tittle, String Ingredients,
    String PhotoUrl, String Category)
{
}