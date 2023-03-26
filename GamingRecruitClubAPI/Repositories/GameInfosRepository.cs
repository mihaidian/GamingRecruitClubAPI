using GamingRecruitClubAPI.DataContext;

namespace GamingRecruitClubAPI.Repositories
{
    public class GameInfosRepository:IGameInfosRepository
    {
        private readonly GamingClubDataContext _context;
        public GameInfosRepository(GamingClubDataContext context)
        {
            _context = context;
        }
    }
}
