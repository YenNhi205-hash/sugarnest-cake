using Application.DTOs;
using MediatR;
using Shared.Models;

namespace Application.Features.Categories.Queries;

public class GetAllCategoriesQuery : IRequest<ApiResponse<List<CategoryDTO>>>
{
}
