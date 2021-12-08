using System;
using System.ComponentModel.DataAnnotations;

namespace Tez.Models
{
    public class Duyuru
    {
        [Key]
        public int DuyuruID { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public string ImageUrl { get; set; }
        public string PaylasanAdmin { get; set; }

    }
}
