using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GamingRecruitClubAPI.DTOs.CreateUpdatedInfos
{
    public class DevInfoUpdate
    {
        [Key]
        public Guid DevID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Developer Experience (In years)")]
        [Required]
        public int DevExperienceInYears { get; set; }
        [Display(Name = "Game Choice")]
        [Required]
        public string GameChoice { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
