namespace fithub_backend.Profiles.Domain.Model.ValueObjects;

public record ObjectiveSelected(string Type)
{
    public ObjectiveSelected() : this(string.Empty)
    {
    }
}