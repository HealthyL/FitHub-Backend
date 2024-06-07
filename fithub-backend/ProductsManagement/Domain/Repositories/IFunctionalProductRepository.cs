using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.ProductsManagement.Domain.Repositories;

public interface IFunctionalProductRepository:IBaseRepository<FunctionalProduct>
{
    Task<FunctionalProduct?> FindByNameAsync(String name);
    Task<IEnumerable<FunctionalProduct>> GetAllAsync();
}