using fithub_backend.ProductsManagement.Domain.Model.Entities;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;

namespace fithub_backend.ProductsManagement.Interfaces.REST.Transform;

public class CategoryResourceFromEntityAssembler
{
    public static CategoryResource toResourceFromEntity(Category entity)
    {
        return new CategoryResource(entity.Id, entity.Name);
    }
}