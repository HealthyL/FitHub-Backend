using fithub_backend.RutinesManagement.Domain.Model.Queries;
using fithub_backend.RutinesManagement.Domain.Services;
using fithub_backend.RutinesManagement.Interfaces.REST.Resources;
using fithub_backend.RutinesManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace fithub_backend.RutinesManagement.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
public class ExercisesController (IExerciseCommandService exerciseCommandService, IExerciseQueryService exerciseQueryService):ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseResource createExerciseResource)
    {
        var createExerciseCommand =
            CreateExerciseCommandFromResourceAssembler
                .ToCommandFromResource(createExerciseResource);
        var exercise = await exerciseCommandService.Handle(createExerciseCommand);
        if (exercise is null) return BadRequest();
        var resource = ExerciseResourceFromEntityAssembler.ToResourceFromEntity(exercise);
        return CreatedAtAction(nameof(CreateExercise), new { exercise = resource.Id }, resource);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllExercises()
    {
        var getAllExercisesQuery = new GetAllExercisesQuery();
        var exercises = await exerciseQueryService.Handle(getAllExercisesQuery);
        var resources = exercises.Select(ExerciseResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    [HttpGet("routine/{routineId}")]
    public async Task<IActionResult> GetExercisesByRoutineId(int routineId)
    {
        var getExercisesByRoutineIdQuery = new GetExerciseByRoutineIdQuery(routineId);
        var exercises = await exerciseQueryService.Handle(getExercisesByRoutineIdQuery);
        var resources = exercises.Select(ExerciseResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
