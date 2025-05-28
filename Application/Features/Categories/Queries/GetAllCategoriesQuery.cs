using Application.DTOs;
using MediatR;
using Shared.Models;

namespace Application.Features.Categories.Queries;

public record GetAllCategoriesQuery : IRequest<ApiResponse<List<CategoryDTO>>>
{
}
