using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;

namespace fithub_backend.ProductsManagement.Interfaces.REST.Transform;

public class CreateCategoryCommandFromResourceAssembler
{
    public static CreateCategoryCommand toCommandFromResource(CreateCategoryResource createCategoryResource)
    {
        return new CreateCategoryCommand(createCategoryResource.Name);
    }
}