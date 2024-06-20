using fithub_backend.NutritionManagement.Domain.Model.Entities;
using fithub_backend.NutritionManagement.Domain.Repositories;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Configuration;
using fithub_backend.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace fithub_backend.NutritionManagement.Infraestructure.Persistence.EFC.Repositories;

public class ClassificationRepository(AppDBContext context)
    : BaseRepository<Classification>(context),
    IClassificationRepository
{
    public async Task<bool> ExistsByIdAsync(int classificationId)
    {
        return await Context.Set<Classification>().AnyAsync
            (classification => classification.Id == classificationId);
    }
}