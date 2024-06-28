namespace fithub_backend.IAM.Domain.Model.Commands;

public record SignUpCommand(string Username, string Email, string BirthDate, string Objective, string Password);