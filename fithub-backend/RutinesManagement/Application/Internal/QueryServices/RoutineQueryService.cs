using fithub_backend.RutinesManagement.Domain.Model.Entities;
using fithub_backend.RutinesManagement.Domain.Model.Queries;
using fithub_backend.RutinesManagement.Domain.Repositories;
using fithub_backend.RutinesManagement.Domain.Services;

namespace fithub_backend.RutinesManagement.Application.Internal.QueryService;

public class RoutineQueryService(IRoutineRepository routineRepository)
    : IRoutineQueryService
{
    public async Task<Routine> Handle(GetRoutineByIdQuery query)
    {
        return await routineRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Routine>> Handle(GetAllRoutinesQuery query)
    {
        return await routineRepository.ListAsync();
    }
}