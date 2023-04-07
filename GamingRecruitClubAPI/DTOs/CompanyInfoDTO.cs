using System.ComponentModel.DataAnnotations;

namespace GamingRecruitClubAPI.DTOs

{
    public class CompanyInfoDTO
    {
        [Key]
        public Guid CompanyId { get; set; }
        [Display(Name = "Company Name")]
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Recruiting?")]
        public bool Recruiting { get; set; }
        [Required]
        [Display(Name = "Member Since")]
        public DateTime? MemberSince { get; set; }
    }
}
