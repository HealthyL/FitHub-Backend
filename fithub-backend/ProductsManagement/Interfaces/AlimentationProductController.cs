using System.Net.Mime;
using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;
using fithub_backend.ProductsManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace fithub_backend.ProductsManagement.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AlimentationProductController(IAlimentationProductCommandService alimentationProductCommandService,
    IAlimentationProductQueryService alimentationProductQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateAlimentationProduct([FromBody] CreateAlimentationProductResource resource)
    {
        var createAlimentationProductCommand =
            CreateAlimentationProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await alimentationProductCommandService.Handle(createAlimentationProductCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetAlimentationProductById), new { id = result.Id },
            AlimentationProductResourceFromEntityToAssembler.ToResourceFromEntity(result));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult>GetAlimentationProductById(int id)
    {
        var getAlimentationProductByIdQuery = new GetAlimentationProductByIdQuery(id);
        var result = await alimentationProductQueryService.Handle(getAlimentationProductByIdQuery);
        if (result is null) return NotFound();
        var resource = AlimentationProductResourceFromEntityToAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllAlimentationProduct()
    {
        var result = await alimentationProductQueryService.Handle(new GetAllAlimentationProductQuery());
        var resource = result.Select(AlimentationProductResourceFromEntityToAssembler.ToResourceFromEntity);
        return Ok(resource);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAlimentationProduct(int id)
    {
        var deleteAlimentationProductCommand = new DeleteAlimentationProductCommand(id);
        var result = await alimentationProductCommandService.Handle(deleteAlimentationProductCommand);
        if (result is null) return NotFound();
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAlimentationProduct(int id, [FromBody] UpdateAlimentationProductResource resource)
    {
        var updateAlimentationProductCommand =
            UpdateAlimentationProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await alimentationProductCommandService.Handle(updateAlimentationProductCommand);
        if (result is null) return NotFound();
        return Ok();
    }
}