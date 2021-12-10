
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var list = _context.Posts.Include(x=>x.PostType).ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult AddPost()
        {           
            var list = _context.PostTypes.ToList();
            return View(list);
        }
        [HttpPost]
        public IActionResult AddPost(PostView d)
        {
            Post duy = new Post();
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
            duy.PostTypeID = d.PostTypeID;
            _context.Posts.Add(duy);
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
        public IActionResult PostSil(int id)
        {
            var dep = _context.Posts.Find(id);
            _context.Posts.Remove(dep);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
