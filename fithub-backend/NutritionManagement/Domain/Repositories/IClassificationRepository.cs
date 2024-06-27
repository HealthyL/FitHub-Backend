using fithub_backend.NutritionManagement.Domain.Model.Entities;
using fithub_backend.Shared.Domain.Repositories;

namespace fithub_backend.NutritionManagement.Domain.Repositories;

public interface IClassificationRepository : IBaseRepository<Classification>
{
    Task<bool> ExistsByIdAsync(int classificationId);
}