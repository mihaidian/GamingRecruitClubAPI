using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GamingRecruitClubAPI.DTOs.CreateUpdatedInfos
{
    public class TesterInfoUpdate
    {
        [Key]
        public Guid TesterID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Tested Before")]
        public bool TestedBefore { get; set; }
        [Display(Name = "Game Choice")]
        public string? GameChoice { get; set; }
        public string? Email { get; set; }
    }
}
