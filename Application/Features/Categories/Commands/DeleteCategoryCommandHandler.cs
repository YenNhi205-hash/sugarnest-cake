using Domain.IRepositories;
using MediatR;
using Shared.Models;

namespace Application.Features.Categories.Commands;

public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<DeleteCategoryCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetById(request.Id);
        if (category == null)
        {
            return new ApiResponse<bool>
            {
                IsSuccess = false,
                Message = "Category not found",
                Data = false
            };
        }

        categoryRepository.Delete(category); // Nếu xài soft delete thì đổi thành status = Deleted
        return new ApiResponse<bool>
        {
            IsSuccess = true,
            Message = "Category deleted successfully",
            Data = true
        };
    }
}
