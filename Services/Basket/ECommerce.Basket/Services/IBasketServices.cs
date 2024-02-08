using ECommerce.Basket.Dtos;

namespace ECommerce.Basket.Services
{
    public interface IBasketServices
    {
        Task<BasketTotalDto> GetBasketTotalDtoAsync(string userId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string userId);
     
    }
}
