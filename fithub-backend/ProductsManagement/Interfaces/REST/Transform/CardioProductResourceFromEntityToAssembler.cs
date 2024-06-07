using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;

namespace fithub_backend.ProductsManagement.Interfaces.REST.Transform;

public class CardioProductResourceFromEntityToAssembler
{
    public static CardioProductResource ToResourceFromEntity(CardioProduct entity)
        => new CardioProductResource(entity.Id, entity.Name, entity.Description, entity.Price, entity.PhotoUrl, entity.Category);
}