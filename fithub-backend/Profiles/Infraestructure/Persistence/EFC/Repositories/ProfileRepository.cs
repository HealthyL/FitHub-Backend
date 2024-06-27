using fithub_backend.Profiles.Domain.Model.Aggregates;
using fithub_backend.Profiles.Domain.Model.ValueObjects;
using fithub_backend.Profiles.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.Profiles.Infraestructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDBContext context) : BaseRepository<Profile>(context), IProfileRepository
{
    public Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<Profile>().Where(p => p.Email == email).FirstOrDefaultAsync();
    }
}