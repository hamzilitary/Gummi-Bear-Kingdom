using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBearKingdom.Models
{
    [Table("Reviewa")]
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }

    }
}
