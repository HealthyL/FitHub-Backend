using fithub_backend.Profiles.Domain.Model.Aggregates;
using fithub_backend.Profiles.Domain.Model.Queries;
using fithub_backend.Profiles.Domain.Repositories;
using fithub_backend.Profiles.Domain.Services;

namespace fithub_backend.Profiles.Application.Internal.QueryService;

public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
{
    public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }

    public async Task<Profile?> Handle(GetProfileByEmailQuery query)
    {
        return await profileRepository.FindProfileByEmailAsync(query.Email);
    }

    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.Id);
    }
}