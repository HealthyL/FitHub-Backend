namespace fithub_backend.ProductsManagement.Domain.Model.Commands;

public record CreateProductCommand(string Name, string Description, string Price, string PhotoUrl, int CategoryId);