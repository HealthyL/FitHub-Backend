using fithub_backend.ProductsManagement.Domain.Model.Entities;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.ProductsManagement.Infraestructure.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<bool> ExistsByIdAsync(int categoryId);
    Task<bool>ExistsByNameAsync(string name);
}