using GamingRecruitClubAPI.DTOs;

namespace GamingRecruitClubAPI.Services
{
    public interface IGameInfosService
    {
        public Task <IEnumerable<GameInfoDTO>> GetGameInfosAsync ();
        public Task <GameInfoDTO> GetGameInfoByIdAsync (Guid id);
        public Task UploadGameAsync(GameInfoDTO newGame);
    }
}
