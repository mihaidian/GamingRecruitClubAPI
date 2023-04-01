using GamingRecruitClubAPI.DataContext;
using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
using Microsoft.EntityFrameworkCore;

namespace GamingRecruitClubAPI.Repositories
{
    public class TesterInfosRepository:ITesterInfosRepository
    {
        private readonly GamingClubDataContext _context;
        public TesterInfosRepository(GamingClubDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TesterInfoDTO>> GetTesterInfosAsync()
        {
            return await _context.Testers.ToListAsync();
        }
        public async Task<TesterInfoDTO> GetTesterInfoByIdAsync(Guid id)
        {
          return await _context.Testers.SingleOrDefaultAsync(a => a.TesterID == id);
        }
        public async Task UploadTesterAsync(TesterInfoDTO tester)
        {
            tester.TesterID = Guid.NewGuid();
            _context.Testers.Add(tester);
            await _context.SaveChangesAsync();

        }

        public Task<TesterInfoUpdate> UpdateTesterAsync(Guid id, TesterInfoUpdate tester)
        {
            throw new NotImplementedException();
        }
    }
}
