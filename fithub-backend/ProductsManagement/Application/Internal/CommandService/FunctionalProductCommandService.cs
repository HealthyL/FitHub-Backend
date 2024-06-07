using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Domain.Repositories;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.ProductsManagement.Application.Internal.CommandService;

public class FunctionalProductCommandService(IFunctionalProductRepository functionalProductRepository,
    IUnitOfWork unitOfWork) : IFunctionalProductCommandService
{
    public async Task<FunctionalProduct> Handle(CreateFunctionalProductCommand command)
    {
        var functionalProduct = await functionalProductRepository.FindByNameAsync(command.Name);
        if (functionalProduct != null)
            throw new Exception("Functional product with this name already exists");
        functionalProduct = new FunctionalProduct(command);
        try
        {
            await functionalProductRepository.AddAsync(functionalProduct);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return functionalProduct;
    }
    public async Task<FunctionalProduct> Handle(UpdateFunctionalProductCommand command)
    {
        var functionalProduct = await functionalProductRepository.FindByIdAsync(command.Id);
        if (functionalProduct == null)
            throw new Exception("Functional product not found");
        functionalProduct.Update(command);
        try
        {
            functionalProductRepository.Update(functionalProduct);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return functionalProduct;
    }
    public async Task<FunctionalProduct> Handle(DeleteFunctionalProductCommand command)
    {
        var functionalProduct = await functionalProductRepository.FindByIdAsync(command.Id);
        if (functionalProduct == null)
            throw new Exception("Functional product not found");
        try
        {
            functionalProductRepository.Remove(functionalProduct);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return functionalProduct;
    }
}