using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutViewComponents : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
