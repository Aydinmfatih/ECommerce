using ECommerce.Services.Catalog.Dtos.CategoryDtos;
using ECommerce.Services.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Services.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var values = await _categoryService.GetCategoryById(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori Başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori Başarıyla silindi");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Güncelleme işlemi gerçekleşti");
        }
    }
}
