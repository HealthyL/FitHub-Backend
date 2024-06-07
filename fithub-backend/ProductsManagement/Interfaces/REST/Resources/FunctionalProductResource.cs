namespace fithub_backend.ProductsManagement.Interfaces.REST.Resources;

public record FunctionalProductResource(
    int Id,
    String Name,
    String Description,
    String Price,
    String PhotoUrl,
    String Category)
{
    
}