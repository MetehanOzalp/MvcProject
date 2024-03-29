﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string SurName { get; set; }

        [StringLength(300)]
        public string ImagePath { get; set; }

        [StringLength(100)]
        public string About { get; set; }

        [StringLength(200)]
        public string Mail { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public bool Status { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
