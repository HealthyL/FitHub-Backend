using fithub_backend.IAM.Domain.Model.Aggregates;
using fithub_backend.IAM.Domain.Model.Queries;
using fithub_backend.IAM.Domain.Repositories;
using fithub_backend.IAM.Domain.Services;

namespace fithub_backend.IAM.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }
    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
}