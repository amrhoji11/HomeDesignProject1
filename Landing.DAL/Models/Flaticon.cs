﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class Flaticon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Design>? Designs { get; set; }

    }
}
