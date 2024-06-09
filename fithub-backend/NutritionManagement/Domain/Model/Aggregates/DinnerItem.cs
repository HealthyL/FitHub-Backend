using fithub_backend.NutritionManagement.Domain.Model.Commands;

namespace fithub_backend.NutritionManagement.Domain.Model.Aggregates;

public class DinnerItem
{
    public int Id { get; private set; }
    public String Tittle { get; private set; }
    public String Ingredients { get; private set; }
    public String PhotoUrl { get; private set; }
    public String Category { get; private set; }
    
    /*
     * This metod is and null constructor
     */
    protected DinnerItem()
    {
        this.Tittle = string.Empty;
        this.Ingredients = string.Empty;
        this.PhotoUrl = string.Empty;
        this.Category = string.Empty;
    }

    /*
     * Basics CRUD
     */
    public DinnerItem(CreateDinnerItemCommand command)
    {
        this.Tittle = command.Tittle;
        this.Ingredients = command.Ingredients;
        this.PhotoUrl = command.PhotoUrl;
        this.Category = command.Category;
    }
    
    public void Update(UpdateDinnerItemCommand command)
    {
        this.Tittle = command.Tittle;
        this.Ingredients = command.Ingredients;
        this.PhotoUrl = command.PhotoUrl;
        this.Category = command.Category;
    }
}