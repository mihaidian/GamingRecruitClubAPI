using GamingRecruitClubAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GamingRecruitClubAPI.DataContext
{
    public class GamingClubDataContext : DbContext
    {
        public GamingClubDataContext(DbContextOptions<GamingClubDataContext> options) : base(options) { }

        public DbSet<DevInfoDTO> Devs { get; set; }
        public DbSet<GameInfoDTO> Games { get; set; }
        public DbSet<TesterInfoDTO> Testers { get; set; }
    }
}
