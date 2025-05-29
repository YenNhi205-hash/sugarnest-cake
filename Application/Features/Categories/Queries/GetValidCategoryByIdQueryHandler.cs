using Application.DTOs;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Shared.Enums;
using Shared.Models;

namespace Application.Features.Categories.Queries;

public class GetValidCategoryByIdQueryHandler
    (ICategoryRepository categoryRepository, IMapper mapper)
    : IRequestHandler<GetValidCategoryByIdQuery, ApiResponse<CategoryDTO>>
{
    public async Task<ApiResponse<CategoryDTO>> Handle(GetValidCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetById(request.Id);

        // ✅ Use Status.Active instead of Status.Valid
        if (category == null || category.Status != Status.Active)
        {
            return new ApiResponse<CategoryDTO>
            {
                IsSuccess = false,
                Message = "Valid (active) category not found",
                Data = null
            };
        }

        var dto = mapper.Map<CategoryDTO>(category);
        return new ApiResponse<CategoryDTO>
        {
            IsSuccess = true,
            Message = "Fetched valid (active) category successfully",
            Data = dto
        };
    }
}
