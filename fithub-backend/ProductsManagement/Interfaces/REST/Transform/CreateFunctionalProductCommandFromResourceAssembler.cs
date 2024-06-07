using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;

namespace fithub_backend.ProductsManagement.Interfaces.REST.Transform;

public class CreateFunctionalProductCommandFromResourceAssembler
{
    public static CreateFunctionalProductCommand ToCommandFromResource(CreateFunctionalProductResource resource)
        => new CreateFunctionalProductCommand(resource.Name, resource.Description, resource.Price, resource.PhotoUrl, resource.Category);
}