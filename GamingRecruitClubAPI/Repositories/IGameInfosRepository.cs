using GamingRecruitClubAPI.DTOs;

namespace GamingRecruitClubAPI.Repositories
{
    public interface IGameInfosRepository
    {
        public Task <IEnumerable<GameInfoDTO>> GetGameInfosAsync ();
        public Task <GameInfoDTO> GetGameInfoByIdAsync (Guid id);
    }
}
