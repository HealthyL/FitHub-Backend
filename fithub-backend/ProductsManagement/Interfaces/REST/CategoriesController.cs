using System.Net.Mime;
using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;
using fithub_backend.ProductsManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace fithub_backend.ProductsManagement.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CategoriesController( ICategoryCommandService categoryCommandService,
    ICategoryQueryService categoryQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a category",
        Description = "Create a category with a given name",
        OperationId = "CreateCategory")]
    [SwaggerResponse(201, "The category was created", typeof(CategoryResource))]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryResource createCategoryResource)
    {
        var createCategoryCommand =
            CreateCategoryCommandFromResourceAssembler.toCommandFromResource(createCategoryResource);
        var category = await categoryCommandService.Handle(createCategoryCommand);
        if (category is null) return BadRequest();
        var resource = CategoryResourceFromEntityAssembler.toResourceFromEntity(category);
        return CreatedAtAction(nameof(CreateCategory), new { categoryId = resource.Id }, resource);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var getAllCategoriesQuery = new GetAllCategoriesQuery();
        var categories = await categoryQueryService.Handle(getAllCategoriesQuery);
        var resources = categories.Select(CategoryResourceFromEntityAssembler.toResourceFromEntity);
        return Ok(resources);
    }
    
}