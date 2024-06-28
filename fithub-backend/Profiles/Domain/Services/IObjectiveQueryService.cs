using fithub_backend.ProductsManagement.Domain.Model.Entities;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.Profiles.Domain.Model;
using fithub_backend.Profiles.Domain.Model.Queries;

namespace fithub_backend.Profiles.Domain.Services;

public interface IObjectiveQueryService
{
    Task<IEnumerable<Objective>> Handle(GetAllObjectivesQuery query);
    Task<Objective?> Handle(GetObjectiveByIdQuery query);
}