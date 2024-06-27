using fithub_backend.IAM.Domain.Model.Aggregates;
using fithub_backend.IAM.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using fithub_backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.IAM.Infrastructure.Persistence.EFC.Repositories;


public class UserRepository(AppDBContext context) : BaseRepository<User>(context), IUserRepository
{

    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
    }
    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }
}