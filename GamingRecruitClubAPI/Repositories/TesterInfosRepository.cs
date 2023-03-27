using GamingRecruitClubAPI.DataContext;
using GamingRecruitClubAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GamingRecruitClubAPI.Repositories
{
    public class TesterInfosRepository:ITesterInfosRepository
    {
        private readonly GamingClubDataContext _context;
        public TesterInfosRepository(GamingClubDataContext context)
        {
            _context = context;
        }

        public async Task<TesterInfoDTO> GetTesterInfoAsync(Guid id)
        {
          return await _context.Testers.SingleOrDefaultAsync(a => a.TesterID == id);
        }

        public async Task<IEnumerable<TesterInfoDTO>> GetTesterInfosAsync()
        {
            return await _context.Testers.ToListAsync();
        }
    }
}
