using fithub_backend.Profiles.Domain.Model.Aggregates;
using fithub_backend.Profiles.Domain.Model.ValueObjects;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}