using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class Massage
    {
        public int Id { get; set; }
        public string YourName { get; set; }
        public string YourMassage { get; set; }

        public int? PProfileId { get; set; }
        public PProfile? Profile { get; set; }



    }
}
