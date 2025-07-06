using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutViewComponents :ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        
        }
    }
}
