using fithub_backend.ProfileManagement.Domain.Model.ValueObjets;

namespace fithub_backend.ProfileManagement.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);