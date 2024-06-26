using fithub_backend.ProductsManagement.Domain.Model.Queries;
using fithub_backend.ProductsManagement.Domain.Services;
using fithub_backend.ProductsManagement.Interfaces.REST.Resources;
using fithub_backend.ProductsManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace fithub_backend.ProductsManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController(IProductCommandService productCommandService, IProductQueryService productQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a product",
        Description = "Create a product with a given name",
        OperationId = "CreateProduct")]
    [SwaggerResponse(201, "The product was created", typeof(ProductResource))]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductResource createProductResource)
    {
        var createProductCommand =
            CreateProductCommandFromResourceAssembler
                .ToCommandFromResource(createProductResource);
        var product = await productCommandService.Handle(createProductCommand);
        if (product is null) return BadRequest();
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(CreateProduct), new { product = resource.Id }, resource);

    }
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var getAllProductsQuery = new GetAllProductsQuery();
        var products = await productQueryService.Handle(getAllProductsQuery);
        var resources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
    {
        var getProductByCategoryIdQuery = new GetProductByCategoryIdQuery(categoryId);
        var products = await productQueryService.Handle(getProductByCategoryIdQuery);
        var resources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
}