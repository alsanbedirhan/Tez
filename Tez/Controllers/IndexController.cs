using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var listtwo = _context.Posts.Include(x=>x.PostType).OrderByDescending(x=>x.Tarih).ToList();
            var listthree = _context.PostTypes.ToList();
            var hi = Tuple.Create<List<Image>, List<Post>, List<PostType>>(listone, listtwo,listthree);                  
            return View(hi);
        }    
    }
}
