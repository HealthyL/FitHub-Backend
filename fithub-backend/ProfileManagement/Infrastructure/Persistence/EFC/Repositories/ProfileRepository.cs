using fithub_backend.ProfileManagement.Domain.Model.ValueObjets;
using fithub_backend.ProfileManagement.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.ProfileManagement.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDBContext context) : BaseRepository<ProfileManagement.Domain.Model.Aggregates.Profile>(context), IProfileRepository
{
    public Task<ProfileManagement.Domain.Model.Aggregates.Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<ProfileManagement.Domain.Model.Aggregates.Profile>().Where(c => c.Email == email).FirstOrDefaultAsync();    
    }
}
