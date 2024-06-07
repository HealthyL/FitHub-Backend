namespace fithub_backend.ProductsManagement.Domain.Model.Commands;

public record UpdateCardioProductCommand (int Id, String Name, String Description, String Price, String PhotoUrl, String Category)
{
    
}