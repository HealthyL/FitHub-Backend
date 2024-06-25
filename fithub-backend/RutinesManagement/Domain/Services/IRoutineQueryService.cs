using fithub_backend.RutinesManagement.Domain.Model.Commands;
using fithub_backend.RutinesManagement.Domain.Model.Entities;
using fithub_backend.RutinesManagement.Domain.Model.Queries;

namespace fithub_backend.RutinesManagement.Domain.Services;

public interface IRoutineQueryService
{
    Task<Routine> Handle(GetRoutineByIdQuery query);
    Task<IEnumerable<Routine>> Handle(GetAllRoutinesQuery query);
}