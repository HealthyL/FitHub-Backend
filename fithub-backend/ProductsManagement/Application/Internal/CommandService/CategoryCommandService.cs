using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Domain.Model.Entities;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.ProductsManagement.Infraestructure.Repositories;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.ProductsManagement.Application.Internal.CommandService;

public class CategoryCommandService(ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : ICategoryCommandService
{
    public async Task<Category> Handle(CreateCategoryCommand command)
    {
        var existsByName = await categoryRepository.ExistsByNameAsync(command.Name);
        if (existsByName) throw new Exception("Category with the same name already exists");

        var category = new Category(command.Name);
        await categoryRepository.AddAsync(category);
        await unitOfWork.CompleteAsync();
        return category;
    }
}