using System.ComponentModel.DataAnnotations;

namespace GamingRecruitClubAPI.DTOs.CreateUpdatedInfos

{
    public class CompanyInfoUpdate
    {
        [Key]
        public Guid CompanyId { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Recruiting?")]
        public bool Recruiting { get; set; }

        [Display(Name = "Member Since")]
        public DateTime MemberSince { get; set; }
    }
}
