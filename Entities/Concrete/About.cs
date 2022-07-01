using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }

        [StringLength(1000)]
        public string Details1 { get; set; }

        [StringLength(1000)]
        public string Details2 { get; set; }

        [StringLength(100)]
        public string ImagePath1 { get; set; }

        [StringLength(100)]
        public string ImagePath2 { get; set; }
    }
}
