using Landing.DAL.Models;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class MassageDetails
    {
        public int Id { get; set; }
        public string YourName { get; set; }

        public string YourMassage { get; set; }
        public PProfile Profile { get; set; }
    }
}
