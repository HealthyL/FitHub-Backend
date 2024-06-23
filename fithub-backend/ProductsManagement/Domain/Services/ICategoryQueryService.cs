using fithub_backend.ProductsManagement.Domain.Model.Entities;
using fithub_backend.ProductsManagement.Domain.Model.Queries;

namespace fithub_backend.ProductsManagement.Domain.Services;

public interface ICategoryQueryService
{
    Task<Category> Handle(GetCategoryByIdQuery query);

    Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
}