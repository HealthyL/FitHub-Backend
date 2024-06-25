using fithub_backend.RutinesManagement.Domain.Model.Commands;
using fithub_backend.RutinesManagement.Domain.Model.Entities;

namespace fithub_backend.RutinesManagement.Domain.Services;

public interface IRoutineCommandService
{
    public Task<Routine> Handle(CreateRoutineCommand command);

}