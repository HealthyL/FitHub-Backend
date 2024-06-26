using fithub_backend.RutinesManagement.Domain.Model.Entities;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.RutinesManagement.Domain.Repositories;

public interface IRoutineRepository:IBaseRepository<Routine>
{
    Task<bool> ExistsByIdAsync(int RoutineId);
    Task<bool> ExistsByNameAsync(string Name);
}