using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultViewComponents :ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
