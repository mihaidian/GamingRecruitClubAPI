using AutoMapper;
using GamingRecruitClubAPI.DataContext;
using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
using Microsoft.EntityFrameworkCore;

namespace GamingRecruitClubAPI.Repositories
{
    public class TesterInfosRepository:ITesterInfosRepository
    {
        private readonly GamingClubDataContext _context;
        private readonly IMapper _mapper;
        public TesterInfosRepository(GamingClubDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<TesterInfoUpdate> UpdateTesterAsync(Guid id, TesterInfoUpdate tester)
        {
            if(! await ExistTesterAsync(id))
            {
                return null;
            }
            var updatedTester=_mapper.Map<TesterInfoDTO>(tester);
            updatedTester.TesterID = id;
            _context.Update(updatedTester);
            await _context.SaveChangesAsync();
            return tester;
        }
        private async Task<bool> ExistTesterAsync(Guid id)
        {
            return await _context.Testers.CountAsync(a => a.TesterID == id) > 0;
        }

        public async Task<TesterInfoUpdate> UpdatePartiallyTesterAsync(Guid id, TesterInfoUpdate tester)
        {
            var testerFromDb=await GetTesterInfoByIdAsync(id);
            if(testerFromDb == null) 
            {
                return null;
            }
            if (!string.IsNullOrEmpty(tester.FirstName) && tester.FirstName != testerFromDb.FirstName)
            {
                testerFromDb.FirstName = tester.FirstName;
            }
            if (!string.IsNullOrEmpty(tester.LastName) && tester.LastName != testerFromDb.LastName)
            {
                testerFromDb.LastName = tester.LastName;
            }
            _context.Testers.Update(testerFromDb);
            await _context.SaveChangesAsync();
            return tester;
        }

        public async Task<bool> DeleteTesterAsync(Guid id)
        {
            TesterInfoDTO tester= await GetTesterInfoByIdAsync(id);
            if(tester== null) 
            {
                return false;
            }
            _context.Testers.Remove(tester);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
