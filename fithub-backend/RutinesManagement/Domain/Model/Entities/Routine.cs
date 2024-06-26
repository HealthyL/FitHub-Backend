using fithub_backend.RutinesManagement.Domain.Model.Aggregates;

namespace fithub_backend.RutinesManagement.Domain.Model.Entities;

public class Routine
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public ICollection<Exercise> Exercises { get; private set; }

    public Routine()
    {
        Name = string.Empty;
    }
    public Routine(string name)
    {
        Name = name;
    }
}