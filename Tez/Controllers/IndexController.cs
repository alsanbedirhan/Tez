﻿using Microsoft.AspNetCore.Mvc;

namespace Tez.Controllers
{  
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
