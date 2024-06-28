using fithub_backend.Profiles.Domain.Model.Aggregates;

namespace fithub_backend.Profiles.Domain.Model;

public class Objective
{
    public int Id { get; }
    public String Name { get; private set; }
    public ICollection<Profile> Profiles { get;  }

    public Objective()
    {
        Name = string.Empty;
    }

    public Objective(string name)
    {
        Name = name;
    }
}