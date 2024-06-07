using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;

namespace fithub_backend.ProductsManagement.Interfaces.REST.Transform;

public class FunctionalProductResourceFromEntityToAssembler
{
    public static FunctionalProductResource ToResourceFromEntity(FunctionalProduct entity)
        => new FunctionalProductResource(entity.Id, entity.Name, entity.Description, entity.Price, entity.PhotoUrl, entity.Category);
}