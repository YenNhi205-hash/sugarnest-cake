using MediatR;
using Shared.Enums;
using Shared.Models;

namespace Application.Features.Categories.Commands;

public class UpdateCategoryStatusCommand : IRequest<ApiResponse<bool>>
{
    public Guid Id { get; set; }
    public Status Status { get; set; }
}
