using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public  class Design
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? FlaticonId { get; set; }
        public Flaticon? Flaticon { get; set; }

        public ICollection<Item>? Items { get; set; }

    }
}
