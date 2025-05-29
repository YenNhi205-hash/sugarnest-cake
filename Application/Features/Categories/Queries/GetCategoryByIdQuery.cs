using Application.DTOs;
using MediatR;
using Shared.Models;

namespace Application.Features.Categories.Queries;

// Add this: : IRequest<ApiResponse<CategoryDTO>>
public class GetCategoryByIdQuery : IRequest<ApiResponse<CategoryDTO>>
{
    public Guid Id { get; set; }

    public GetCategoryByIdQuery(Guid id)
    {
        Id = id;
    }
}
