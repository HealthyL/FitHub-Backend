using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Domain.Model.Entities;
namespace fithub_backend.NutritionManagement.Domain.Model.Aggregates;
 
public partial class Nutrition
{
    public int Id { get; private set; }
    
    public string Name { get; private set; }
    
    public string Description { get; private set; }
    
    public string PhotoUrl { get; private set; }
    
    public Classification Classification { get; private set; } // Breakfast, Lunch, Dinner
    
    public int ClassificationId { get; private set; }

    public Nutrition(string name, string description,
        string photoUrl, int classificationId)
    {
        Name = name;
        Description = description;
        PhotoUrl = photoUrl;
        ClassificationId = classificationId;
    }
    
    //funcion de Update
    public void Update(UpdateNutritionCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        PhotoUrl = command.PhotoUrl;
        ClassificationId = command.ClassificationId;
    }
    
}