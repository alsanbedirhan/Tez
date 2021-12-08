using System;
using System.ComponentModel.DataAnnotations;

namespace Tez.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        public string ImageURL { get; set; }
        public string PaylasanAdmin { get; set; }
        public DateTime Tarih { get; set; }

    }
}
