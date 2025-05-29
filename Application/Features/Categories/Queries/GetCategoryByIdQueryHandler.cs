using Application.DTOs;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Shared.Models;

namespace Application.Features.Categories.Queries;

public class GetCategoryByIdQueryHandler
    (ICategoryRepository categoryRepository, IMapper mapper)
    : IRequestHandler<GetCategoryByIdQuery, ApiResponse<CategoryDTO>>
{
    public async Task<ApiResponse<CategoryDTO>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetById(request.Id);

        if (category == null)
        {
            return new ApiResponse<CategoryDTO>
            {
                IsSuccess = true,
                Message = "Category not found",
                Data = null
            };
        }

        var dto = mapper.Map<CategoryDTO>(category);
        return new ApiResponse<CategoryDTO>
        {
            IsSuccess = true,
            Message = "Fetch category successfully",
            Data = dto
        };
    }
}
