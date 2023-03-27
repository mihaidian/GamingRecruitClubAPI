using GamingRecruitClubAPI.DataContext;
using GamingRecruitClubAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GamingRecruitClubAPI.Repositories
{
    public class GameInfosRepository:IGameInfosRepository
    {
        private readonly GamingClubDataContext _context;
        public GameInfosRepository(GamingClubDataContext context)
        {
            _context = context;
        }

        public async Task<GameInfoDTO> GetGameInfoByIdAsync(Guid id)
        {
            return await _context.Games.SingleOrDefaultAsync(a => a.GameID == id);
        }

        public async Task<IEnumerable<GameInfoDTO>> GetGameInfosAsync()
        {
            return await _context.Games.ToListAsync();
        }
    }
}
