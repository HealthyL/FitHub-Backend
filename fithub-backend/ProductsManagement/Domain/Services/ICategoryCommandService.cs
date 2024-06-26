using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Domain.Model.Entities;

namespace fithub_backend.ProductsManagement.Domain.Services;

public interface ICategoryCommandService
{
    public Task<Category> Handle(CreateCategoryCommand command);
}