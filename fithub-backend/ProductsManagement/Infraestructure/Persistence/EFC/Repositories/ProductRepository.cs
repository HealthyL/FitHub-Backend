using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Infraestructure.Repositories;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.ProductsManagement.Infraestructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDBContext context):BaseRepository<Product>(context), IProductRepository
{

    public async Task<bool> ExistsByCategoryIdAndProductNameAsync(int categoryId, string productName)
    {
        return await Context.Set<Product>()
            .AnyAsync(product => product.CategoryId == categoryId && product.Name == productName);
    }
    public async Task<IEnumerable<Product>> FindByCategoryIdAsync(int categoryId)
    {
        return await Context.Set<Product>()
            //Include(product=>product.CategoryId)
            .Where(product => product.CategoryId == categoryId)
            .ToListAsync();
    }
}