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
    public Task<IActionResult> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("/valid/{id}")]
    public Task<IActionResult> GetValidById(Guid id)
    {
        throw new NotImplementedException();
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
    public Task<IActionResult> UpdateStatus(Guid id, Status status)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
