namespace fithub_backend.IAM.Interfaces.REST.Resources;

public record SignUpResource(string Username, string Password, string Email, string BirthDate, string Objective);