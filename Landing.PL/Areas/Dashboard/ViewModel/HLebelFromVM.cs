﻿namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class HLebelFromVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
