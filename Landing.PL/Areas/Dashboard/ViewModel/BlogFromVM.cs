using Landing.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class BlogFromVM
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int? SelectItemId { get; set; }
        public SelectList? ItemList { get; set; }
    }
}
