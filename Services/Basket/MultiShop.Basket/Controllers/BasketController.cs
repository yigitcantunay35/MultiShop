using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail() 
        {
            var user = User.Claims; // bunu ekledik buraya.
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SavaMyBasket(BasketTotalDto basketTotalDto) 
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SavaBasket(basketTotalDto);
            return Ok("Sepetteki değişikler kaydedildi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket() 
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepet silme işlemi başarılı");
        }
    }
}
