using Microsoft.AspNetCore.Http;
using System;

namespace Tez.Models
{
    public class ImageView
    {
        public IFormFile ImageURL { get; set; }
        public string PaylasanAdmin { get; set; }
        public DateTime Tarih { get; set; }
    }
}
