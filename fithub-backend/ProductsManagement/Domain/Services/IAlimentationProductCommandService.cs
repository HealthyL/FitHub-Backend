using fithub_backend.ProductsManagement.Domain.Model.Aggregates;
using fithub_backend.ProductsManagement.Domain.Model.Commands;

namespace fithub_backend.ProductsManagement.Domain.Services;

public interface IAlimentationProductCommandService
{
    Task<AlimentationProduct?> Handle(CreateAlimentationProductCommand command);
}