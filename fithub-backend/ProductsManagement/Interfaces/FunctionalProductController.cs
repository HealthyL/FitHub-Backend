using System.Net.Mime;
using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.ProductsManagement.Domain.Repositories;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;
using fithub_backend.ProductsManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace fithub_backend.ProductsManagement.Interfaces;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class FunctionalProductController(IFunctionalProductQueryService functionalProductQueryService,
    IFunctionalProductCommandService functionalProductCommandService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult> GetFunctionalProductById(int id)
    {
        var getFunctionalProductByIdQuery = new GetFunctionalProductByIdQuery(id);
        var result = await functionalProductQueryService.Handle(getFunctionalProductByIdQuery);
        if (result is null) return NotFound();
        var resource = FunctionalProductResourceFromEntityToAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllFunctionalProduct()
    {
        var result = await functionalProductQueryService.Handle(new GetAllFunctionalProductQuery());
        var resource = result.Select(FunctionalProductResourceFromEntityToAssembler.ToResourceFromEntity);
        return Ok(resource);
    }
    [HttpPost]
    public async Task<ActionResult> CreateFunctionalProduct([FromBody] CreateFunctionalProductResource resource)
    {
        var createFunctionalProductCommand =
            CreateFunctionalProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await functionalProductCommandService.Handle(createFunctionalProductCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetFunctionalProductById), new { id = result.Id },
            FunctionalProductResourceFromEntityToAssembler.ToResourceFromEntity(result));
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateFunctionalProduct(int id, [FromBody] UpdateFunctionalProductResource resource)
    {
        var updateFunctionalProductCommand =
            UpdateFunctionalProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await functionalProductCommandService.Handle(updateFunctionalProductCommand);
        if (result is null) return BadRequest();
        return Ok(FunctionalProductResourceFromEntityToAssembler.ToResourceFromEntity(result));
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteFunctionalProduct(int id)
    {
        var deleteFunctionalProductCommand = new DeleteFunctionalProductCommand(id);
        var result = await functionalProductCommandService.Handle(deleteFunctionalProductCommand);
        if (result is null) return NotFound();
        return Ok(FunctionalProductResourceFromEntityToAssembler.ToResourceFromEntity(result));
    }
}