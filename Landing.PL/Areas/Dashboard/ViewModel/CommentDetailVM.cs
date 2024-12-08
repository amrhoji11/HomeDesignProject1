using Landing.DAL.Models;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class CommentDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
       
        public PProfile Profile { get; set; }
    }
}
