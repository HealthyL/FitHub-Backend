using fithub_backend.ProfileManagement.Domain.Model.ValueObjets;
using fithub_backend.Shared.Domain.Repositories;
using Profile = fithub_backend.ProfileManagement.Domain.Model.Aggregates.Profile;

namespace fithub_backend.ProfileManagement.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<ProfileManagement.Domain.Model.Aggregates.Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}