using ECommerce.Discount.Dtos;

namespace ECommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponsAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task DeleteCouponAsync(int id);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task<ResultCouponDto> GetCouponById(int id);
    }
}
