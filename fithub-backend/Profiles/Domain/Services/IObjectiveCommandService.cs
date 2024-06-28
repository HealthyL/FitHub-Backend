using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Domain.Model.Entities;
using fithub_backend.Profiles.Domain.Model;
using fithub_backend.Profiles.Domain.Model.Commands;

namespace fithub_backend.Profiles.Domain.Services;

public interface IObjectiveCommandService
{
    Task<Objective?> Handle(CreateObjectiveCommand command);
}