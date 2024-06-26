using System.Net.Mime;
using fithub_backend.RutinesManagement.Domain.Model.Queries;
using fithub_backend.RutinesManagement.Domain.Services;
using fithub_backend.RutinesManagement.Interfaces.REST.Resources;
using fithub_backend.RutinesManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace fithub_backend.RutinesManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class RoutinesController(IRoutineCommandService routineCommandService,
    IRoutineQueryService routineQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a routine",
        Description = "Create a routine with a given name",
        OperationId = "CreateRoutine")]
    [SwaggerResponse(201, "The routine was created", typeof(RoutineResource))]
    public async Task<IActionResult> CreateRoutine([FromBody] CreateRoutineResource createRoutineResource)
    {
        var createRoutineCommand =
            CreateRoutineCommandFromResourceAssembler.
                ToCommandFromResource(createRoutineResource);
        var routine = await routineCommandService.Handle(createRoutineCommand);
        if (routine is null) return BadRequest();
        var resource = RoutineResourceFromEntityAssembler.ToResourceFromEntity(routine);
        return CreatedAtAction(nameof(CreateRoutine), new { routineId = resource.Id }, resource);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllRoutines()
    {
        var getAllRoutinesQuery = new GetAllRoutinesQuery();
        var routines = await routineQueryService.Handle(getAllRoutinesQuery);
        var resources = routines.Select(RoutineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
}