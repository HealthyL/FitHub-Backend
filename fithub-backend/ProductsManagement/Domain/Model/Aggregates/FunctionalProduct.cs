using fithub_backend.ProductsManagement.Domain.Model.Commands;
using Mysqlx.Crud;

namespace fithub_backend.ProductsManagement.Domain.Model.Aggregates;

public class FunctionalProduct
{
    public int Id { get; private set; }
    public String Name { get; private set; }
    public String Description { get; private set; }
    public String Price { get; private set; }
    public String PhotoUrl { get; private set; }
    public String Category { get; private set; }
    

    protected FunctionalProduct()
    {
        this.Name=string.Empty;
        this.Description=string.Empty;
        this.Price=string.Empty;
        this.PhotoUrl=string.Empty;
        this.Category=string.Empty;
    }

    public FunctionalProduct(CreateFunctionalProductCommand command)
    {
        this.Name=command.Name;
        this.Description=command.Description;
        this.Price=command.Price;
        this.PhotoUrl=command.PhotoUrl;
        this.Category=command.Category;
    }

    public void Update(UpdateFunctionalProductCommand command)
    {
        this.Name = command.Name;
        this.Description = command.Description;
        this.Price = command.Price;
        this.PhotoUrl = command.PhotoUrl;
        this.Category = command.Category;
    }
}