﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultViewComponents : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
