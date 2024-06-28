using fithub_backend.Profiles.Domain.Model;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.Profiles.Domain.Repositories;

public interface IObjectiveRepository: IBaseRepository<Objective>
{
    Task<bool>ExistsByNameAsync(string name);
}
