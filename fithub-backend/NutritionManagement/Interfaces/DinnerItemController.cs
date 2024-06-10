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
public class DinnerItemController : ControllerBase
{
    private readonly IDinnerItemCommandService _dinnerItemCommandService;
    private readonly IDinnerItemQueryService _dinnerItemQueryService;

    public DinnerItemController(IDinnerItemCommandService dinnerItemCommandService,
        IDinnerItemQueryService dinnerItemQueryService)
    {
        _dinnerItemCommandService = dinnerItemCommandService;
        _dinnerItemQueryService = dinnerItemQueryService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateDinnerItem([FromBody] CreateDinnerItemResource resource)
    {
        var createDinnerItemCommand =
            CreateDinnerItemCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _dinnerItemCommandService.Handle(createDinnerItemCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetDinnerItemById), new { id = result.Id },
            DinnerItemResourceFromEntityToAssembler.ToResourceFromEntity(result));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetDinnerItemById(int id)
    {
        var getDinnerItemByIdQuery = new GetDinnerItemByIdQuery(id);
        var result = await _dinnerItemQueryService.Handle(getDinnerItemByIdQuery);
        if (result is null) return NotFound();
        var resource = DinnerItemResourceFromEntityToAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllDinnerItems()
    {
        var result = await _dinnerItemQueryService.Handle(new GetAllDinnerItemsQuery());
        var resource = result.Select(DinnerItemResourceFromEntityToAssembler.ToResourceFromEntity);
        return Ok(resource);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDinnerItem(int id)
    {
        var deleteDinnerItemCommand = new DeleteDinnerItemCommand(id);
        var result = await _dinnerItemCommandService.Handle(deleteDinnerItemCommand);
        if (result is null) return NotFound();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDinnerItem(int id, [FromBody] UpdateDinnerItemResource resource)
    {
        var updateDinnerItemCommand =
            UpdateDinnerItemCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await _dinnerItemCommandService.Handle(updateDinnerItemCommand);
        if (result is null) return NotFound();
        return Ok();
    }
}