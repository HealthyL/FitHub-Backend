using fithub_backend.Profiles.Domain.Model.ValueObjects;

namespace fithub_backend.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);