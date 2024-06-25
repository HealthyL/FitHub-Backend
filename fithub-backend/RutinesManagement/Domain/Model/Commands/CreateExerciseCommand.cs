namespace fithub_backend.RutinesManagement.Domain.Model.Commands;

public record CreateExerciseCommand(string Name, string PhotoUrl, int Sets, int Reps, string Weight, int RoutineId);