using System.Net.Mime;
using fithub_backend.NutritionManagement.Domain.Model.Queries;
using fithub_backend.NutritionManagement.Domain.Services;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;
using fithub_backend.NutritionManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace fithub_backend.NutritionManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ClassificationController(IClassificationCommandService classificationCommandService,
    IClassificationQueryService classificationQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a classification",
        Description = "Create a classification with a given name",
        OperationId = "CreateClassification")]
    [SwaggerResponse(201, "The classification was created", typeof(ClassificationResource))]
    
    public async Task<IActionResult> CreateClassification([FromBody] CreateClassificationResource createClassificationResource)
    {
        var createClassificationCommand =
            CreateClassificationCommandFromResourceAssembler.toCommandFromResource(createClassificationResource);
        var classification = await classificationCommandService.Handle(createClassificationCommand);
        if (classification is null) return BadRequest();
        var resource = ClassificationResourceFromEntityAssembler.toResourceFromEntity(classification);
        return CreatedAtAction(nameof(CreateClassification), new { classificationId = resource.Id }, resource);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllClassifications()
    {
        var getAllClassificationsQuery = new GetAllClassificationsQuery();
        var classifications = await classificationQueryService.Handle(getAllClassificationsQuery);
        var resources = classifications.Select(ClassificationResourceFromEntityAssembler.toResourceFromEntity);
        return Ok(resources);
    }
}
