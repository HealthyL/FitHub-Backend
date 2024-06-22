using fithub_backend.ProfileManagement.Domain.Model.Commands;
using fithub_backend.ProfileManagement.Domain.Repositories;
using fithub_backend.ProfileManagement.Domain.Services;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.ProfileManagement.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task<Domain.Model.Aggregates.Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Domain.Model.Aggregates.Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}
