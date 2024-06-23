using fithub_backend.ProductsManagement.Domain.Model.Entities;
using fithub_backend.ProductsManagement.Infraestructure.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.ProductsManagement.Infraestructure.Persistence.EFC.Repositories;

public class CategoryRepository(AppDBContext context): BaseRepository<Category>(context),
    ICategoryRepository
{
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await Context.Set<Category>().AnyAsync(category => category.Name == name);
    }
    
    public async Task<bool> ExistsByIdAsync(int categoryId)
    {
        return await Context.Set<Category>().AnyAsync(category => category.Id == categoryId);
    }
}