using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopbarUILayoutViewComponents :ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        
        }
    }
}
