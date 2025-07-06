using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureDefaultViewComponents :ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
            
        }
    }
}
