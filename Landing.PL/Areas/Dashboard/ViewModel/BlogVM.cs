using Landing.DAL.Models;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class BlogVM
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? ItemId { get; set; }
        public Item Item { get; set; }
    }
}
