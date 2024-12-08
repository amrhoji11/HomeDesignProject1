using Landing.DAL.Models;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class BlogDetail
    {
        public int Id { get; set; }
        public string Content { get; set; }

       
        public Item Item { get; set; }
    }
}
