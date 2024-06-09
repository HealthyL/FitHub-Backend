using fithub_backend.NutritionManagement.Domain.Model.Commands;
namespace fithub_backend.NutritionManagement.Domain.Model.Aggregates;

public class LunchItem
{
    public int Id { get; private set; }
    public String Tittle { get; private set; }
    public String Description { get; private set; }
    public String PhotoUrl { get; private set; }
    public String Category { get; private set; }

    /*
     * This metod is and null constructor
     */
    protected LunchItem()
    {
        this.Tittle = string.Empty;
        this.Description = string.Empty;
        this.PhotoUrl = string.Empty;
        this.Category = string.Empty;
    }

    /*
     * Basics CRUD
     */
    public LunchItem(CreateLunchItemCommand command)
    {
        this.Tittle = command.Tittle;
        this.Description = command.Description;
        this.PhotoUrl = command.PhotoUrl;
        this.Category = command.Category;
    }
}