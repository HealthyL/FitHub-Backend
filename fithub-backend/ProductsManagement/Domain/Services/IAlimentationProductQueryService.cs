using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Queries;

namespace fithub_backend.ProductsManagement.Domain.Services;

public interface IAlimentationProductQueryService
{
    Task<AlimentationProduct?> Handle(GetAlimentationProductByIdQuery query);

    Task<IEnumerable<AlimentationProduct>> Handle(GetAllAlimentationProductQuery query);

}