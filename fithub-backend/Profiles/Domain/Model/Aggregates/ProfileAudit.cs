using System.ComponentModel.DataAnnotations.Schema;

namespace fithub_backend.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}