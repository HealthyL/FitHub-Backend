﻿using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Domain.Repositories;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.ProductsManagement.Application.Internal.CommandService;

public class CardioProductCommandService(ICardioProductRepository cardioProductRepository,
    IUnitOfWork unitOfWork) : ICardioProductCommandService
{
    public async Task<CardioProduct> Handle(CreateCardioProductCommand command)
    {
        var cardioProduct = await cardioProductRepository.FindByNameAsync(command.Name);
        if (cardioProduct != null)
            throw new Exception("Cardio product with this name already exists");
        cardioProduct = new CardioProduct(command);
        try
        {
            await cardioProductRepository.AddAsync(cardioProduct);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }
        return cardioProduct;
    }
}