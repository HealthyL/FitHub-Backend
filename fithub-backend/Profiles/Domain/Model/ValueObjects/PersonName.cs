namespace fithub_backend.Profiles.Domain.Model.ValueObjects;

public record PersonName(string FullName)
{
    public PersonName() : this(string.Empty)
    {
    }
}