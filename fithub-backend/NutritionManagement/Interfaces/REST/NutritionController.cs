using fithub_backend.NutritionManagement.Domain.Model.Commands;
using fithub_backend.NutritionManagement.Domain.Model.Queries;
using fithub_backend.NutritionManagement.Domain.Services;
using fithub_backend.NutritionManagement.Interfaces.REST.Resources;
using fithub_backend.NutritionManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace fithub_backend.NutritionManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class NutritionController(INutritionCommandService nutritionCommandService, INutritionQueryService nutritionQueryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateNutrition([FromBody] CreateNutritionResource createNutritionResource)
    {
        var createNutritionCommand = 
            CreateNutritionCommandFromResourceAssembler
                .ToCommandFromResource(createNutritionResource);
        var nutrition = await nutritionCommandService.Handle(createNutritionCommand);
        if (nutrition is null) return BadRequest();
        var resource = NutritionResourceFromEntityAssembler.toResourceFromEntity(nutrition);
        return CreatedAtAction(nameof(CreateNutrition), new { nutrition = resource.Id }, resource);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateNutrition([FromBody] UpdateNutritionResource updateNutritionResource)
    {
        var updateNutritionCommand = 
            UpdateNutritionCommandFromResourceAssembler
                .ToCommandFromResource(updateNutritionResource);
        var nutrition = await nutritionCommandService.Handle(updateNutritionCommand);
        if (nutrition is null) return BadRequest();
        var resource = NutritionResourceFromEntityAssembler.toResourceFromEntity(nutrition);
        return Ok(resource);
    }
    
    [HttpDelete("{nutritionId}")]
    public async Task<IActionResult> DeleteNutrition(int nutritionId)
    {
        var deleteNutritionCommand = new DeleteNutritionCommand(nutritionId);
        var nutrition = await nutritionCommandService.Handle(deleteNutritionCommand);
        if (nutrition is null) return BadRequest();
        var resource = NutritionResourceFromEntityAssembler.toResourceFromEntity(nutrition);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNutritionsQuery()
    {
        var getAllNutritionsQuery = new GetAllNutritionsQuery();
        var nutritions = await nutritionQueryService.Handle(getAllNutritionsQuery);
        var resources = nutritions.Select(NutritionResourceFromEntityAssembler.toResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("classification/{nutritionId}")]
    public async Task<IActionResult> GetNutritionByClassificationIdQuery(int classificationId)
    {
        var getNutritionByClassificationIdQuery = new GetNutritionByClassificationIdQuery(classificationId);
        var nutritions = await nutritionQueryService.Handle(getNutritionByClassificationIdQuery);
        var resources = nutritions.Select(NutritionResourceFromEntityAssembler.toResourceFromEntity);
        return Ok(resources);
    }
    
}