using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;

namespace fithub_backend.ProductsManagement.Interfaces.REST.Transform;

public class UpdateFunctionalProductCommandFromResourceAssembler
{
public static UpdateFunctionalProductCommand ToCommandFromResource(UpdateFunctionalProductResource resource)
        => new UpdateFunctionalProductCommand(resource.Id, resource.Name, resource.Description, resource.Price, resource.PhotoUrl, resource.Category);
}