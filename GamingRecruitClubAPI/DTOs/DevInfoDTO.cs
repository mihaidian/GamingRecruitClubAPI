using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GamingRecruitClubAPI.DTOs
{
    public class DevInfoDTO
    {
        [Key]
        public Guid DevID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        [Display(Name = "Developer Experience (In years)")]
        public int? DevExperienceInYears { get; set; }
        [Display(Name = "Game Choice")]
        public string GameChoice { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
