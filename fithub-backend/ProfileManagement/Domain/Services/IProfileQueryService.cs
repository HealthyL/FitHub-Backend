using fithub_backend.ProfileManagement.Domain.Model.Aggregates;
using fithub_backend.ProfileManagement.Domain.Model.Queries;

namespace fithub_backend.ProfileManagement.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile?>> Handle(GetAllProfilesQuery query);
    Task<Profile?> Handle(GetProfileByEmailQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
}