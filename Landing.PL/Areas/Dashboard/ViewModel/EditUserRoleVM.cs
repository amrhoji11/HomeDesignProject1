using Microsoft.AspNetCore.Mvc.Rendering;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class EditUserRoleVM
    {
        public string Id { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }
        public string? SelectedRoles { get; set; }
    }
}
