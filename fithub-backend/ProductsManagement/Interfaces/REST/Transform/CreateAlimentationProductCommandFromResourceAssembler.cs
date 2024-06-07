using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;

namespace fithub_backend.ProductsManagement.Interfaces.REST.Transform;

public class CreateAlimentationProductCommandFromResourceAssembler
{
    public static CreateAlimentationProductCommand ToCommandFromResource(CreateAlimentationProductResource resource)
        => new CreateAlimentationProductCommand(resource.Name, resource.Description, resource.Price, resource.PhotoUrl, resource.Category);
}