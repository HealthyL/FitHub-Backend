using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;

namespace fithub_backend.ProductsManagement.Interfaces.REST.Transform;

public class AlimentationProductResourceFromEntityToAssembler
{
    public static AlimentationProductResource ToResourceFromEntity(AlimentationProduct entity)
        => new AlimentationProductResource(entity.Id, entity.Name, entity.Description, entity.Price, entity.PhotoUrl, entity.Category);
}