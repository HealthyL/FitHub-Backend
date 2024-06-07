namespace fithub_backend.ProductsManagement.Interfaces.REST.Resources;

public record CreateCardioProductResource (
    String Name, 
    String Description,
    String Price, 
    String PhotoUrl, 
    String Category)
{
    
}