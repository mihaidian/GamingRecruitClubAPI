using AutoMapper;
using GamingRecruitClubAPI.DataContext;
using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace GamingRecruitClubAPI.Repositories
{
    public class GameInfosRepository:IGameInfosRepository
    {
        private readonly GamingClubDataContext _context;
        private readonly IMapper _mapper;
        public GameInfosRepository(GamingClubDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GameInfoDTO> GetGameInfoByIdAsync(Guid id)
        {
            return await _context.Games.SingleOrDefaultAsync(a => a.GameID == id);
        }

        public async Task<IEnumerable<GameInfoDTO>> GetGameInfosAsync()
        {
            return await _context.Games.ToListAsync();
        }
        public async Task UploadGameAsync(GameInfoDTO game)
        {
            game.GameID = Guid.NewGuid();
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task<GameInfoUpdate> UpdateGameAsync(Guid id, GameInfoUpdate game)
        {
            if(! await ExistGameAsync(id))
            {
                return null;
            }
            var updatedGame=_mapper.Map<GameInfoDTO>(game);
            updatedGame.GameID = id;
            _context.Update(updatedGame);
            await _context.SaveChangesAsync();
            return game;
        }
        private async Task<bool> ExistGameAsync(Guid id)
        {
            return await _context.Games.CountAsync(a => a.GameID == id) > 0;
        }

        public async Task<GameInfoUpdate> UpdatePartiallyGameAsync(Guid id, GameInfoUpdate game)
        {
            var gameFromDb= await GetGameInfoByIdAsync(id);
            if(gameFromDb==null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(game.GameName) && game.GameName != gameFromDb.GameName)
            {
                gameFromDb.GameName = game.GameName;
            }
            _context.Games.Update(gameFromDb);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<bool> DeleteGameAsync(Guid id)
        {
            GameInfoDTO game= await GetGameInfoByIdAsync(id);
            if(game==null)
            {
                return false;
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
