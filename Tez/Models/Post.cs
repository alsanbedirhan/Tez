using System;
using System.ComponentModel.DataAnnotations;

namespace Tez.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string Aciklama { get; set; }
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
        public string ImageUrl { get; set; }
        public string PaylasanAdmin { get; set; }
        public int PostTypeID { get; set; }
        public PostType PostType { get; set; }

    }
}
