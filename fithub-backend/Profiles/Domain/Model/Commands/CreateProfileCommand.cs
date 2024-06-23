namespace fithub_backend.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string FullName, string Email, string BirthDate, string Objective);