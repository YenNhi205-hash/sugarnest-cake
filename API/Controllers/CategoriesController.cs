using Application.Features.Categories.Commands;
using Application.Features.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var req = new GetAllCategoriesQuery();
        var result = await mediator.Send(req);
        return Ok(result);
    }

    [HttpGet("/valid")]
    public Task<IActionResult> GetAllValid()
    {
        throw new NotImplementedException();
    }

    [HttpGet("deleted")]
    public Task<IActionResult> GetAllDeleted()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var req = new GetCategoryByIdQuery(id);
        var result = await mediator.Send(req);
        return Ok(result);
    }

    [HttpGet("valid/{id}")]
    public async Task<IActionResult> GetValidById(Guid id)
    {
        var req = new GetValidCategoryByIdQuery(id);
        var result = await mediator.Send(req);
        return Ok(result);
    }

    [HttpPost]
    public Task<IActionResult> Create()
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public Task<IActionResult> Update(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromQuery] Status status)
    {
        try
        {
            var req = new UpdateCategoryStatusCommand { Id = id, Status = status };
            var result = await mediator.Send(req);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var req = new DeleteCategoryCommand { Id = id };
        var result = await mediator.Send(req);
        return Ok(result);
    }

}
