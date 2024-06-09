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
public class BreakfastItemController : ControllerBase
{
    private readonly IBreakfastItemCommandService _breakfastItemCommandService;
    private readonly IBreakfastItemQueryService _breakfastItemQueryService;

    public BreakfastItemController(IBreakfastItemCommandService breakfastItemCommandService,
        IBreakfastItemQueryService breakfastItemQueryService)
    {
        _breakfastItemCommandService = breakfastItemCommandService;
        _breakfastItemQueryService = breakfastItemQueryService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateBreakfastItem([FromBody] CreateBreakfastItemResource resource)
    {
        var createBreakfastItemCommand =
            CreateBreakfastItemCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _breakfastItemCommandService.Handle(createBreakfastItemCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetBreakfastItemById), new { id = result.Id },
            BreakfastItemResourceFromEntityToAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetBreakfastItemById(int id)
    {
        var getBreakfastItemByIdQuery = new GetBreakfastItemByIdQuery(id);
        var result = await _breakfastItemQueryService.Handle(getBreakfastItemByIdQuery);
        if (result is null) return NotFound();
        var resource = BreakfastItemResourceFromEntityToAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllBreakfastItems()
    {
        var result = await _breakfastItemQueryService.Handle(new GetAllBreakfastItemsQuery());
        var resource = result.Select(BreakfastItemResourceFromEntityToAssembler.ToResourceFromEntity);
        return Ok(resource);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBreakfastItem(int id)
    {
        var deleteBreakfastItemCommand = new DeleteBreakfastItemCommand(id);
        var result = await _breakfastItemCommandService.Handle(deleteBreakfastItemCommand);
        if (result is null) return NotFound();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBreakfastItem(int id, [FromBody] UpdateBreakfastItemResource resource)
    {
        var updateBreakfastItemCommand =
            UpdateBreakfastItemCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _breakfastItemCommandService.Handle(updateBreakfastItemCommand);
        if (result is null) return NotFound();
        return Ok();
    }
}