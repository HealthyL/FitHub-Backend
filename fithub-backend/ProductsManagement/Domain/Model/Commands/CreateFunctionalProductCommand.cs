namespace fithub_backend.ProductsManagement.Domain.Model.Commands;

public record CreateFunctionalProductCommand(String Name,String Description,String Price, String PhotoUrl, String Category);