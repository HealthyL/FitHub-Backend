using fithub_backend.NutritionManagement.Domain.Model.Aggregates;

namespace fithub_backend.NutritionManagement.Domain.Model.Entities;

public class Classification
{
    public int Id { get; set; }
    public string Name { get; set; } //Breakfast, Lunch, Dinner
    
    public ICollection<Nutrition> Nutritions { get;  }

    public Classification()
    {
        Name = string.Empty;
    }

    public Classification(string name)
    {
        Name = name;
    }
}