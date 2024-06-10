using System.Net.Mime;
using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Domain.Model.Queries;
using fithub_backend.NutritionManagement.Domain.Services;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;
using fithub_backend.NutritionManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace fithub_backend.NutritionManagement.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class LunchItemController : ControllerBase
{
    private readonly ILunchItemCommandService _lunchItemCommandService;
    private readonly ILunchItemQueryService _lunchItemQueryService;

    public LunchItemController(ILunchItemCommandService lunchItemCommandService,
        ILunchItemQueryService lunchItemQueryService)
    {
        _lunchItemCommandService = lunchItemCommandService;
        _lunchItemQueryService = lunchItemQueryService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateLunchItem([FromBody] CreateLunchItemResource resource)
    {
        var createLunchItemCommand =
            CreateLunchItemCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _lunchItemCommandService.Handle(createLunchItemCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetLunchItemById), new { id = result.Id },
            LunchItemResourceFromEntityToAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetLunchItemById(int id)
    {
        var getLunchItemByIdQuery = new GetLunchItemByIdQuery(id);
        var result = await _lunchItemQueryService.Handle(getLunchItemByIdQuery);
        if (result is null) return NotFound();
        var resource = LunchItemResourceFromEntityToAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllLunchItems()
    {
        var result = await _lunchItemQueryService.Handle(new GetAllLunchItemsQuery());
        var resource = result.Select(LunchItemResourceFromEntityToAssembler.ToResourceFromEntity);
        return Ok(resource);
    }
}
