using System.Net.Mime;
using fithub_backend.Profiles.Domain.Model.Queries;
using fithub_backend.Profiles.Domain.Services;
using fithub_backend.Profiles.Interfaces.REST.Resources;
using fithub_backend.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace fithub_backend.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ObjectivesController(IObjectiveCommandService objectiveCommandService, IObjectiveQueryService objectiveQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Objective",
        Description = "Create a Objective with a given name",
        OperationId = "CreateObjective")]
    [SwaggerResponse(201, "The Objective was created", typeof(ObjectiveResource))]
    public async Task<IActionResult> CreateObjective([FromBody] CreateObjectiveResource createObjectiveResource)
    {
        var createObjectiveCommand =
            CreateObjectiveCommandFromResourceAssembler.ToCommandFromResource(createObjectiveResource);
        var objective = await objectiveCommandService.Handle(createObjectiveCommand);
        if (objective is null) return BadRequest();
        var resource = ObjectiveResourceFromEntityAssembler.ToResourceFromEntity(objective);
        return CreatedAtAction(nameof(CreateObjective), new { ObjectiveId = resource.id }, resource);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var getAllObjectivesQuery = new GetAllObjectivesQuery();
        var objectives = await objectiveQueryService.Handle(getAllObjectivesQuery);
        var resources = objectives.Select(ObjectiveResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}