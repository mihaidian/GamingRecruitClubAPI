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
    }
}
