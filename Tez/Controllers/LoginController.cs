﻿using Tez.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tez.Controllers
{    
    public class LoginController : Controller
    {
        private readonly Context _context;
        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email, string sifre)
        {
            var bytes = new System.Text.UTF8Encoding().GetBytes(sifre);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            sifre = Convert.ToBase64String(hashBytes);

            var user = _context.Admins.FirstOrDefault(x => x.Email.Equals(email) && x.Sifre.Equals(sifre));
            if (user != null)
            {
                HttpContext.Session.SetInt32("id", user.AdminID);
                HttpContext.Session.SetString("fullname", user.Name+" "+user.Surname);           
                return Redirect("/Admin/Index");
            }
            return Redirect("Index");
        }

        //register ilk admin hesabı oluşturulması için admin hesabı olmadan hesap eklemeye izin verilmiştir
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(Admin a)
        {
            var bytes = new System.Text.UTF8Encoding().GetBytes(a.Sifre);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            a.Sifre = Convert.ToBase64String(hashBytes);

            await _context.AddAsync(a);
            await _context.SaveChangesAsync();
            return Redirect("/Login/Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Index/Index");
        }
    }
}
