namespace fithub_backend.ProductsManagement.Interfaces.REST.Resources;

public record ProductResource(
    int Id,
    string Name,
    string Description,
    string Price,
    string PhotoUrl,
    int CategoryId);