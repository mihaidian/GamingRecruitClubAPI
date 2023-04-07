using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GamingRecruitClubAPI.DTOs
{
    public class GameInfoDTO
    {
        [Key]
        public Guid GameID { get; set; }

        [Display(Name = "Game Name")]
        public string GameName { get; set; }


        [Display(Name = "Added On")]
        public DateTime? AddedOn { get; set; }


        [Display(Name = "Available for test?")]
        public bool AvailableForTest { get; set; }


        [Display(Name = "Dead Line")]
        public DateTime? DeadLine { get; set; }


        [Display(Name = "Available for developing?")]
        public bool AvailableForDeveloping { get; set; }


        public string? Developer { get; set; }
    }
}
