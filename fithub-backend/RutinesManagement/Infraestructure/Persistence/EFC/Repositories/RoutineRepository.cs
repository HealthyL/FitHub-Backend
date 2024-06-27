using fithub_backend.RutinesManagement.Domain.Model.Entities;
using fithub_backend.RutinesManagement.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.RutinesManagement.Infraestructure.Persistence.EFC.Repositories;

public class RoutineRepository (AppDBContext context): BaseRepository<Routine>(context),
    IRoutineRepository
{
    public async Task<bool> ExistsByNameAsync(string Name)
    {
        return await Context.Set<Routine>().AnyAsync(routine => routine.Name == Name);
    }
    
    public async Task<bool> ExistsByIdAsync(int RoutineId)
    {
        return await Context.Set<Routine>().AnyAsync(routine => routine.Id == RoutineId);
    }
}