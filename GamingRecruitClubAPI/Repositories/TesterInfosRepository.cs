using GamingRecruitClubAPI.DataContext;

namespace GamingRecruitClubAPI.Repositories
{
    public class TesterInfosRepository:ITesterInfosRepository
    {
        private readonly GamingClubDataContext _context;
        public TesterInfosRepository(GamingClubDataContext context)
        {
            _context = context;
        }
    }
}
