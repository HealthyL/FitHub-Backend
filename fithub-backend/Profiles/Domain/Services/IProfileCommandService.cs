using fithub_backend.Profiles.Domain.Model.Aggregates;
using fithub_backend.Profiles.Domain.Model.Commands;

namespace fithub_backend.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);

}