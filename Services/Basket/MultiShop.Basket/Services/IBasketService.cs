using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string userId);
        Task SavaBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string userId);
    }
}
