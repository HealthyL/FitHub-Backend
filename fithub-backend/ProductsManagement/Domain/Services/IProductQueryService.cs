using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Queries;

namespace fithub_backend.ProductsManagement.Domain.Services;

public interface IProductQueryService
{
    Task<IEnumerable<Product>> Handle(GetAllProducts query);
    Task<IEnumerable<Product>> Handle(GetProductByCategoryId query);
}