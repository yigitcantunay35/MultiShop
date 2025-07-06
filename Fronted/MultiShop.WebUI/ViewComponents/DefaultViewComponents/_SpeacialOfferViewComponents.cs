using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpeacialOfferViewComponents :ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
