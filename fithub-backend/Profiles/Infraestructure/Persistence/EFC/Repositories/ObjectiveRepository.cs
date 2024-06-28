using fithub_backend.Profiles.Domain.Model;
using fithub_backend.Profiles.Domain.Repositories;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.Profiles.Infraestructure.Persistence.EFC.Repositories;

public class ObjectiveRepository(AppDBContext context) : BaseRepository<Objective>(context), IObjectiveRepository
{
    public async Task<bool>ExistsByNameAsync(string name)
    {
        return await Context.Set<Objective>().Where(o => o.Name == name).AnyAsync();
    }
}