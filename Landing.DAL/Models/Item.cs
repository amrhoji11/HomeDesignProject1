﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public  class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreateAt { get; set; }
        public string? ImageName { get; set; }

        public int? DesignId { get; set; }
        public Design? Design { get; set; }

        public Blog? Blog { get; set; }
    }
}
