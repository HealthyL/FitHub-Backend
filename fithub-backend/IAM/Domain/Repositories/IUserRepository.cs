using fithub_backend.IAM.Domain.Model.Aggregates;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}