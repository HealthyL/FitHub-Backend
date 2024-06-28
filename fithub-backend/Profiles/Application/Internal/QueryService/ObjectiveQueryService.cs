using fithub_backend.Profiles.Domain.Model;
using fithub_backend.Profiles.Domain.Model.Queries;
using fithub_backend.Profiles.Domain.Repositories;
using fithub_backend.Profiles.Domain.Services;

namespace fithub_backend.Profiles.Application.Internal.QueryService;

public class ObjectiveQueryService(IObjectiveRepository profileRepository) : IObjectiveQueryService
{
    public async Task<IEnumerable<Objective>> Handle(GetAllObjectivesQuery query)
    {
        return await profileRepository.ListAsync();
    }

    public async Task<Objective?> Handle(GetObjectiveByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.Id);
    }
}