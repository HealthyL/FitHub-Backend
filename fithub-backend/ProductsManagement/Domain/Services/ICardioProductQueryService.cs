using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Queries;

namespace fithub_backend.ProductsManagement.Domain.Services;

public interface ICardioProductQueryService
{
    Task<CardioProduct?> Handle(GetCardioProductByIdQuery query);
    Task<IEnumerable<CardioProduct>> Handle(GetAllCardioProductQuery query);
}