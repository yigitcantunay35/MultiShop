using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutViewComponents:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
