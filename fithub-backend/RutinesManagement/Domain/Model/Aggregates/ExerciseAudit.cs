using System.ComponentModel.DataAnnotations.Schema;

namespace fithub_backend.RutinesManagement.Domain.Model.Aggregates;

public partial class Exercise
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}