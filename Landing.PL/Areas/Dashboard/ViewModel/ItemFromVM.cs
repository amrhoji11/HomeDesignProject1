//using Landing.DAL.Data.Migrations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class ItemFromVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }

        public int? DesignId { get; set; }

        public SelectList? Design { get; set; }
       
    }
}
