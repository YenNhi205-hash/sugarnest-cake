using Application.DTOs;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Shared.Models;


namespace Application.Features.Categories.Queries;

public class GetAllCategoriesQueryHandler 
    (ICategoryRepository categoryRepository, IMapper mapper)
    : IRequestHandler<GetAllCategoriesQuery, ApiResponse<List<CategoryDTO>>>
{
    public async Task<ApiResponse<List<CategoryDTO>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var data = await categoryRepository.GetAll();
        var DTOs = mapper.Map<List<CategoryDTO>>(data);
        return new ApiResponse<List<CategoryDTO>>
        {
            IsSuccess = true,
            Message = "Fetchs all categories successfully",
            Data = DTOs
        };
    }
}
