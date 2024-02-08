using ECommerce.Basket.Dtos;
using ECommerce.Basket.Settings;

namespace ECommerce.Basket.Services
{
    public class BasketService : IBasketServices
    {
        private readonly RedisSettings _redisSettings;

        public BasketService(RedisSettings redisSettings)
        {
            _redisSettings = redisSettings;
        }

        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<BasketTotalDto> GetBasketTotalDtoAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            throw new NotImplementedException();
        }
    }
}
