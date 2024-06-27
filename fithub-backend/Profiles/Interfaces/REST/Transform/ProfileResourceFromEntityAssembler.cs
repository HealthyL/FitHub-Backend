﻿using fithub_backend.Profiles.Domain.Model.Aggregates;
using fithub_backend.Profiles.Interfaces.REST.Resources;

namespace fithub_backend.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.FullName, entity.EmailAddress, entity.BirthDate, entity.ObjectiveType);
    }
}