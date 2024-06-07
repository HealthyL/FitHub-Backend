using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.ProductsManagement.Domain.Repositories;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.ProductsManagement.Infraestructure.Repositories;

public class AlimentationProductQueryService (IAlimentationProductRepository alimentationProductsRepository) : IAlimentationProductQueryService
{
    public async Task<AlimentationProduct?> Handle(GetAlimentationProductByIdQuery query)
    {
        return await alimentationProductsRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<AlimentationProduct>> Handle(GetAllAlimentationProductQuery query)
    {
        return await alimentationProductsRepository.GetAllAsync();
    }
}