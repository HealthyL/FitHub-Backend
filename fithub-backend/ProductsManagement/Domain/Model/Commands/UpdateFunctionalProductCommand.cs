namespace fithub_backend.ProductsManagement.Domain.Model.Commands;

public record UpdateFunctionalProductCommand (int Id, string Name, string Description, string Price, string PhotoUrl, string Category)
{
    
}