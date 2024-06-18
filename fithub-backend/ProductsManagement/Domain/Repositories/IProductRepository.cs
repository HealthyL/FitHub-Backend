using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.ProductsManagement.Infraestructure.Repositories;

public interface IProductRepository:IBaseRepository<Product>
{
    Task<bool> ExistsByCategoryIdAndProductNameAsync(int categoryId, string productName);
    Task<IEnumerable<Product>> FindByCategoryIdAsync(int categoryId);
}