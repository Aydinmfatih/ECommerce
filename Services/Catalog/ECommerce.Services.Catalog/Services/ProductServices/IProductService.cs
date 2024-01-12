using ECommerce.Services.Catalog.Dtos.CategoryDtos;
using ECommerce.Services.Catalog.Dtos.ProductDtos;

namespace ECommerce.Services.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<ResultProductDto> GetProductAsync(string id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
    }
}
