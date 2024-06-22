using fithub_backend.ProfileManagement.Domain.Model.Aggregates;
using fithub_backend.ProfileManagement.Domain.Model.Commands;

namespace fithub_backend.ProfileManagement.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}