
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using Tez.Filter;
using Tez.Models;

namespace Tez.Controllers
{
    [UserFilter]
    public class AdminController : Controller
    {
        private readonly Context _context;
        public AdminController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Duyurus.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPost(DuyuruView d)
        {         
            Duyuru duy = new Duyuru();
            if(d.ImageUrl!= null)
            {
                var extension = Path.GetExtension(d.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/image/", newimagename);
                var stream = new FileStream(location,FileMode.Create);
                d.ImageUrl.CopyTo(stream);
                duy.ImageUrl = newimagename;
            }
            duy.PaylasanAdmin= HttpContext.Session.GetString("fullname");
            duy.Baslik = d.Baslik;
            duy.Aciklama = d.Aciklama;
            duy.Tarih = DateTime.Now;
            _context.Duyurus.Add(duy);
            _context.SaveChanges();
            return RedirectToAction("Index");           
        }
        [HttpGet]
        public IActionResult Photo()
        {
            var list = _context.Images.ToList();
            return View(list);
        }
        [HttpPost]
        public IActionResult Photo(ImageView i)
        {
            Image ima = new Image();
            if (i.ImageURL != null)
            {
                var extension = Path.GetExtension(i.ImageURL.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/main/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                i.ImageURL.CopyTo(stream);
                ima.ImageURL = newimagename;
            }
            ima.PaylasanAdmin = HttpContext.Session.GetString("fullname");
            ima.Tarih = DateTime.Now;
            _context.Images.Add(ima);
            _context.SaveChanges();
            return RedirectToAction("Photo");
        }
        public IActionResult PhotoSil(int id)
        {
            var dep = _context.Images.Find(id);
            _context.Images.Remove(dep);
            _context.SaveChanges();
            return RedirectToAction("Photo");
        }
    }
}
