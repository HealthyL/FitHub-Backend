using fithub_backend.ProfileManagement.Domain.Model.Commands;
using fithub_backend.ProfileManagement.Interfaces.REST.Resources;

namespace fithub_backend.ProfileManagement.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.FirstName, resource.LastName, resource.Email, resource.Street,
            resource.Number, resource.City, resource.PostalCode, resource.Country);
    }
}