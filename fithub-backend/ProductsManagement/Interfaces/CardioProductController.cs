using System.Net.Mime;
using fithub_backend.ProductsManagement.Domain.Model.Commands;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;
using fithub_backend.ProductsManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace fithub_backend.ProductsManagement.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CardioProductController (ICardioProductCommandService cardioProductCommandService,
    ICardioProductQueryService cardioProductQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateCardioProduct([FromBody] CreateCardioProductResource resource)
    {
        var createCardioProductCommand =
            CreateCardioProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await cardioProductCommandService.Handle(createCardioProductCommand);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetCardioProductById), new { id = result.Id },
            CardioProductResourceFromEntityToAssembler.ToResourceFromEntity(result));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult>GetCardioProductById(int id)
    {
        var getCardioProductByIdQuery = new GetCardioProductByIdQuery(id);
        var result = await cardioProductQueryService.Handle(getCardioProductByIdQuery);
        if (result is null) return NotFound();
        var resource = CardioProductResourceFromEntityToAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    [HttpGet]
    public async Task<ActionResult> GetAllCardioProduct()
    {
        var result = await cardioProductQueryService.Handle(new GetAllCardioProductQuery());
        var resource = result.Select(CardioProductResourceFromEntityToAssembler.ToResourceFromEntity);
        return Ok(resource);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCardioProduct(int id, [FromBody] UpdateCardioProductResource resource)
    {
        var updateCardioProductCommand = 
            UpdateCardioProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await cardioProductCommandService.Handle(updateCardioProductCommand);
        if (result is null) return NotFound();
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCardioProduct(int id)
    {
        var deleteCardioProductCommand = new DeleteCardioProductCommand(id);
        var result = await cardioProductCommandService.Handle(deleteCardioProductCommand);
        if (result is null) return NotFound();
        return Ok();
    }
}