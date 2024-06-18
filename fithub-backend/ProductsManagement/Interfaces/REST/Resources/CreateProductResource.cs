namespace fithub_backend.ProductsManagement.Interfaces.REST.Resources;

public record CreateProductResource(
    string Name,
    string Description,
    string Price,
    string PhotoUrl,
    int CategoryId);