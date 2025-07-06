using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultViewComponents : ViewComponent //Yani isimlendirme ile componentin nerede çalıştığını belirttik.
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        
        }
    }
}
