using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.ProductsManagement.Domain.Repositories;

public interface ICardioProductRepository: IBaseRepository<CardioProduct>
{
    Task<CardioProduct?> FindByNameAsync(String name);
    Task<IEnumerable<CardioProduct>> GetAllAsync();
    Task<CardioProduct?> Handle(int id);
}