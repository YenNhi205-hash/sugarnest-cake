using Application.Features.Categories.Commands;
using Domain.IRepositories;
using MediatR;
using Shared.Models;

public class UpdateCategoryStatusCommandHandler
    (ICategoryRepository categoryRepository)
    : IRequestHandler<UpdateCategoryStatusCommand, ApiResponse<bool>>
{
    public async Task<ApiResponse<bool>> Handle(UpdateCategoryStatusCommand request, CancellationToken cancellationToken)
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

        category.Status = request.Status;
        categoryRepository.Update(category);
        await categoryRepository.SaveAsync(); // ✅ Gọi SaveAsync sau khi cập nhật

        return new ApiResponse<bool>
        {
            IsSuccess = true,
            Message = "Category status updated successfully",
            Data = true
        };
    }
}
