using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Queries;

namespace fithub_backend.ProductsManagement.Domain.Services;

public interface IFunctionalProductQueryService
{
    Task<FunctionalProduct?> Handle(GetFunctionalProductByIdQuery query);
    Task<IEnumerable<FunctionalProduct>> Handle(GetAllFunctionalProductQuery query);
}