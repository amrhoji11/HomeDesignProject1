using Microsoft.AspNetCore.Mvc.Rendering;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class DesignsFromVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int? SelectedFlaticonId { get; set; }
        public SelectList? FlaticonList { get; set; } // قائمة الـ Flaticons
    }
}
