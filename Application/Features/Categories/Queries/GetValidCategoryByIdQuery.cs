using Application.DTOs;
using MediatR;
using Shared.Models;

namespace Application.Features.Categories.Queries;

public class GetValidCategoryByIdQuery : IRequest<ApiResponse<CategoryDTO>>
{
    public Guid Id { get; set; }

    public GetValidCategoryByIdQuery(Guid id)
    {
        Id = id;
    }
}
