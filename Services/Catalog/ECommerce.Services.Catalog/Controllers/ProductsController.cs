using ECommerce.Services.Catalog.Dtos.ProductDtos;
using ECommerce.Services.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Services.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var values = await _ProductService.GetAllProductsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var values = await _ProductService.GetProductAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _ProductService.CreateProductAsync(createProductDto);
            return Ok("Ürün Başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _ProductService.DeleteProductAsync(id);
            return Ok("Ürün Başarıyla silindi");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _ProductService.UpdateProductAsync(updateProductDto);
            return Ok("Güncelleme işlemi gerçekleşti");
        }
    }
}
