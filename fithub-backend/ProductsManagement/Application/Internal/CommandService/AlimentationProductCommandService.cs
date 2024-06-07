using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Domain.Repositories;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.ProductsManagement.Application.Internal.CommandService;

public class AlimentationProductCommandService (IAlimentationProductRepository alimentationProductRepository, 
    IUnitOfWork unitOfWork) :IAlimentationProductCommandService
{
    public async Task<AlimentationProduct?> Handle(CreateAlimentationProductCommand command)
    {
        var alimentationProduct = await alimentationProductRepository.FindByNameAsync(command.Name); 
        if (alimentationProduct != null)
            throw new Exception("Alimentation product with this name already exists");
        alimentationProduct = new AlimentationProduct(command);
        try
        {
            await alimentationProductRepository.AddAsync(alimentationProduct);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return alimentationProduct;
    }
    public async Task<AlimentationProduct?> Handle(DeleteAlimentationProductCommand command)
    {
        var alimentationProduct = await alimentationProductRepository.FindByIdAsync(command.Id);
        if (alimentationProduct == null)
            throw new Exception("Alimentation product not found");
        try
        {
            alimentationProductRepository.Remove(alimentationProduct);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return alimentationProduct;
    }
    public async Task<AlimentationProduct?> Handle(UpdateAlimentationProductCommand command)
    {
        var alimentationProduct = await alimentationProductRepository.FindByIdAsync(command.Id);
        if (alimentationProduct == null)
            throw new Exception("Alimentation product not found");
        alimentationProduct.Update(command);
        try
        {
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return alimentationProduct;
    }
}