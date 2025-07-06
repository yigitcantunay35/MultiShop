using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultViewComponents: ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
