using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutViewComponents :ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
