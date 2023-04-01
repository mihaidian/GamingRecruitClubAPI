using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GamingRecruitClubAPI.DTOs.CreateUpdatedInfos
{
    public class TesterInfoUpdate
    {
        [Key]
        public Guid TesterID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Tested Before")]
        public bool TestedBefore { get; set; }
        [Required]
        [Display(Name = "Game Choice")]
        public string GameChoice { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
