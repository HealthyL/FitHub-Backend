using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.ProductsManagement.Domain.Repositories;
using fithub_backend.ProductsManagement.Domain.Services;

namespace fithub_backend.ProductsManagement.Application.Internal.QueryService;

public class FunctionalProductQueryService (IFunctionalProductRepository functionalProductRepository) : IFunctionalProductQueryService
{
    public async Task<FunctionalProduct?> Handle(GetFunctionalProductByIdQuery query)
    {
        return await functionalProductRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<FunctionalProduct>> Handle(GetAllFunctionalProductQuery query)
    {
        return await functionalProductRepository.GetAllAsync();
    }
}