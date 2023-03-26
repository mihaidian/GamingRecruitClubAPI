using GamingRecruitClubAPI.Repositories;

namespace GamingRecruitClubAPI.Services
{
    public class TesterInfosService:ITesterInfosService
    {
        private readonly ITesterInfosRepository _repository; 
        public TesterInfosService(ITesterInfosRepository repository)
        {
            _repository = repository;
        }
    }
}
