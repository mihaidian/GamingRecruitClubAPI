using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.Repositories;

namespace GamingRecruitClubAPI.Services
{
    public class GameInfosService:IGameInfosService
    {
        private readonly IGameInfosRepository _repository;
        public GameInfosService(IGameInfosRepository repository)
        {
            _repository = repository;
        }

        public async Task<GameInfoDTO> GetGameInfoByIdAsync(Guid id)
        {
            return await _repository.GetGameInfoByIdAsync(id);
        }

        public async Task<IEnumerable<GameInfoDTO>> GetGameInfosAsync()
        {
            return await _repository.GetGameInfosAsync();
        }
    }
}
