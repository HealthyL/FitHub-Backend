using fithub_backend.ProductsManagement.Domain.Model.Aggregates;

namespace fithub_backend.ProductsManagement.Domain.Model.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Product> Products { get;  }

    public Category()
    {
        Name = string.Empty;
    }

    public Category(string name)
    {
        Name = name;
    }
}