namespace fithub_backend.Profiles.Domain.Model.ValueObjects;

public record BirthDate(string Date)
{
    public BirthDate() : this(string.Empty)
    {
    }
}