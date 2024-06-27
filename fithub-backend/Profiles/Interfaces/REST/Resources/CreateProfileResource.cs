namespace fithub_backend.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(string FullName, string Email, string BirthDate, string Objective);