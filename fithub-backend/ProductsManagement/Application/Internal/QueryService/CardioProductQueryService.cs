using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.ProductsManagement.Domain.Repositories;
using fithub_backend.ProductsManagement.Domain.Services;

namespace fithub_backend.ProductsManagement.Application.Internal.QueryService;

public class CardioProductQueryService (ICardioProductRepository cardioProductsRepository) : ICardioProductQueryService
{
    public async Task<CardioProduct?> Handle(GetCardioProductByIdQuery query)
    {
        return await cardioProductsRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<CardioProduct>> Handle(GetAllCardioProductQuery query)
    {
        return await cardioProductsRepository.GetAllAsync();
    }
}