using ECommerce.Services.Catalog.Dtos.CategoryDtos;

namespace ECommerce.Services.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<ResultCategoryDto> GetCategoryById(string id);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);

    }
}
