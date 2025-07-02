﻿using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {

            //var existBasket = await _redisService.GetDb().StringGetAsync(userId); // ← NULL dönebilir! => eski kod
            //return JsonSerializer.Deserialize<BasketTotalDto>(existBasket); // ← NULL json deserialize edilemez  => eski kod
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);

            if (string.IsNullOrEmpty(existBasket)) // ← kritik kontrol
                return null;
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SavaBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
