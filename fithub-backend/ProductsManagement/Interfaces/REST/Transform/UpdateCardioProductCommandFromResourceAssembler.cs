using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;

namespace fithub_backend.ProductsManagement.Interfaces.REST.Transform;

public class UpdateCardioProductCommandFromResourceAssembler
{
    public static UpdateCardioProductCommand ToCommandFromResource(UpdateCardioProductResource resource)
        => new UpdateCardioProductCommand(resource.Id, resource.Name, resource.Description, resource.Price, resource.PhotoUrl, resource.Category);
}