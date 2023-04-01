using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;

namespace GamingRecruitClubAPI.Repositories
{
    public interface IGameInfosRepository
    {
        public Task <IEnumerable<GameInfoDTO>> GetGameInfosAsync();
        public Task <GameInfoDTO> GetGameInfoByIdAsync (Guid id);
        public Task UploadGameAsync(GameInfoDTO game);
        public Task<GameInfoUpdate> UpdateGameAsync(Guid id, GameInfoUpdate updatedGame);
    }
}
