using MediatR;
using Shared.Models;

namespace Application.Features.Categories.Commands;

public class DeleteCategoryCommand : IRequest<ApiResponse<bool>>
{
    public Guid Id { get; set; }
}
