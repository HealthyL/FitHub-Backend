namespace fithub_backend.RutinesManagement.Interfaces.REST.Resources;

public record ExerciseResource(int Id, string Name, string PhotoUrl, int Sets, int Reps, string Weight, int RoutineId);