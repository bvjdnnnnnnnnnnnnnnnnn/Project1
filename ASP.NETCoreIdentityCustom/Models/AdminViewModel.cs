using ASP.NETCoreIdentityCustom.Areas.Identity.Data;

namespace ASP.NETCoreIdentityCustom.Models
{
    public class AdminViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public string Task { get; set; }
        public string AssigneeId { get; set; }
        public DateTime DueDate { get; set; }
        
    }

}
