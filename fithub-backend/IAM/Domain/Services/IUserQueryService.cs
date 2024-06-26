using fithub_backend.IAM.Domain.Model.Aggregates;
using fithub_backend.IAM.Domain.Model.Queries;

namespace fithub_backend.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}