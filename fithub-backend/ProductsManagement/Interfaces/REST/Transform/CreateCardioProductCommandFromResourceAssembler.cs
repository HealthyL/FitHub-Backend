using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;

namespace fithub_backend.ProductsManagement.Interfaces.REST.Transform;

public class CreateCardioProductCommandFromResourceAssembler
{
    public static CreateCardioProductCommand ToCommandFromResource(CreateCardioProductResource resource)
        => new CreateCardioProductCommand(resource.Name, resource.Description, resource.Price, resource.PhotoUrl, resource.Category);
}