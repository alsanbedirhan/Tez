using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tez.Models
{
    public class PostType
    {
        [Key]
        public int PostTypeID { get; set; }
        public string TypeName { get; set; }

        public IList<Post> Posts { get; set; }

    }
}
