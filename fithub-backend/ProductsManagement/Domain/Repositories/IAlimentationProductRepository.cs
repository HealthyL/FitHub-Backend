using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.ProductsManagement.Domain.Repositories;

public interface IAlimentationProductRepository : IBaseRepository<AlimentationProduct>
{
    Task<AlimentationProduct?> FindByNameAsync(String name);
    Task<IEnumerable<AlimentationProduct>> GetAllAsync();
    Task<AlimentationProduct?> Handle(int id);
}