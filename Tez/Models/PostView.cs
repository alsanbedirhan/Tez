using Microsoft.AspNetCore.Http;
using System;

namespace Tez.Models
{
    public class PostView
    {
        public string Aciklama { get; set; }
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string PaylasanAdmin { get; set; }
        public int PostTypeID { get; set; }
    }
}
