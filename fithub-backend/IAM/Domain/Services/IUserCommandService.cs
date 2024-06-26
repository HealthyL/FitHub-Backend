using fithub_backend.IAM.Domain.Model.Aggregates;
using fithub_backend.IAM.Domain.Model.Commands;

namespace fithub_backend.IAM.Domain.Services;

public interface IUserCommandService
{
    Task<(User user, string token)> Handle(SignInCommand command);
    Task Handle(SignUpCommand command);
}