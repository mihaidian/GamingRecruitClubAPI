using GamingRecruitClubAPI.DataContext;
using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
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

        public Task<GameInfoUpdate> UpdateGameAsync(Guid id, GameInfoUpdate updatedGame)
        {
            throw new NotImplementedException();
        }

        public async Task UploadGameAsync(GameInfoDTO game)
        {
            game.GameID=Guid.NewGuid();
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }
    }
}
