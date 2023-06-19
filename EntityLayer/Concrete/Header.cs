using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Header
    {
        [Key]
        public int HeaderId { get; set; }

        [StringLength(50)]
        public string HeaderName { get; set; }
        public DateTime HeaderDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
