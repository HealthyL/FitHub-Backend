using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.ProductsManagement.Infraestructure.Repositories;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.ProductsManagement.Application.Internal.QueryService;

public class ProductQueryService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductQueryService
{
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.Id);
    }
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
    {
        return await productRepository.ListAsync();
    }

    public async Task<IEnumerable<Product>> Handle(GetProductByCategoryIdQuery query)
    {
        return await productRepository.FindByCategoryIdAsync(query.CategoryId);
    }
}