using fithub_backend.RutinesManagement.Domain.Model.Entities;

namespace fithub_backend.RutinesManagement.Domain.Model.Aggregates;

public partial class Exercise
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string PhotoUrl { get; private set; }
    public int Sets { get; private set; }
    public int Reps { get; private set; }
    public string Weight { get; private set; }
    public Routine Routine {get; private set;}
    public int RoutineId { get; private set; }

    public Exercise(string name, string photoUrl, int sets, int reps, string weight, int routineId)
    {
        Name = name;
        PhotoUrl = photoUrl;
        Sets = sets;
        Reps = reps;
        Weight = weight;
        RoutineId = routineId;
    }

}