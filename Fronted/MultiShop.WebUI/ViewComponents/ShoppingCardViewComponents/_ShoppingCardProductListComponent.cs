using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ShoppingCardViewComponents
{
    public class _ShoppingCardProductListComponent:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
