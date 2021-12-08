using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Tez.Models;

namespace Tez.Controllers
{  
    public class IndexController : Controller
    {
        private readonly Context _context;
        public IndexController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listone = _context.Images.ToList();
            var listtwo = _context.Duyurus.ToList();
            var hi = Tuple.Create<List<Image>, List<Duyuru>>(listone, listtwo);                  
            return View(hi);
        }
    }
}
