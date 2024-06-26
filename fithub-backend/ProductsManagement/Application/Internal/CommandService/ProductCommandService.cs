using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.ProductsManagement.Infraestructure.Repositories;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.ProductsManagement.Application.Internal.CommandService;

public class ProductCommandService(IProductRepository productRepository,ICategoryRepository categoryRepository , IUnitOfWork unitOfWork) : IProductCommandService
{
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        var categoryExists = await categoryRepository.ExistsByIdAsync(command.CategoryId);
        if (!categoryExists) throw new Exception("Category Id does not exist");

        var existsByCategoryIdAndProductName = await productRepository.ExistsByCategoryIdAndProductNameAsync(command.CategoryId, command.Name);
        if (existsByCategoryIdAndProductName) throw new Exception("Product with the same Category Id and Product Name already exists");

        var product = new Product(command.Name, command.Description, command.Price, command.PhotoUrl, command.CategoryId);
        await productRepository.AddAsync(product);
        await unitOfWork.CompleteAsync();
        return product;
    }
}