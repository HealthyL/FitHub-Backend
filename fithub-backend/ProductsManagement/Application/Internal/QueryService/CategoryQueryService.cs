using fithub_backend.ProductsManagement.Domain.Model.Entities;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.ProductsManagement.Infraestructure.Repositories;

namespace fithub_backend.ProductsManagement.Application.Internal.QueryService;

public class CategoryQueryService(ICategoryRepository categoryRepository) : ICategoryQueryService
{
    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await categoryRepository.FindByIdAsync(query.Id);
    }
    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
    {
        return await categoryRepository.ListAsync();
    }
}