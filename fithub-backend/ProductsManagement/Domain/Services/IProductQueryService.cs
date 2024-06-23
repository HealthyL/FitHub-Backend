using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Queries;

namespace fithub_backend.ProductsManagement.Domain.Services;

public interface IProductQueryService
{
    Task<Product?> Handle(GetProductByIdQuery query);

    Task<IEnumerable<Product>> Handle(GetAllProductsQuery query);
    Task<IEnumerable<Product>> Handle(GetProductByCategoryIdQuery query);
}