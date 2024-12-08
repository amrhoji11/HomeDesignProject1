//using Landing.DAL.Data.Migrations;
using Landing.DAL.Models;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class ItemDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageName { get; set; }


       
        public DateTime CreatedAt { get; set; }

        public Design Design { get; set; } 
    }
}
