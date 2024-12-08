using Landing.DAL.Models;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class DesignDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Flaticon Flaticon { get; set; }
    }
}
