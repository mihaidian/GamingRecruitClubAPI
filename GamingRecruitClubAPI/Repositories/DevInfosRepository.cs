using GamingRecruitClubAPI.DataContext;
using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
using Microsoft.EntityFrameworkCore;

namespace GamingRecruitClubAPI.Repositories
{
    public class DevInfosRepository:IDevInfosRepository
    {
        private readonly GamingClubDataContext _context;
            public DevInfosRepository(GamingClubDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DevInfoDTO>> GetDevInfosAsync()
        {
            return await _context.Devs.ToListAsync();
        }
        public async Task<DevInfoDTO> GetDevInfoByIdAsync(Guid id)
        {
            return await _context.Devs.SingleOrDefaultAsync(a=>a.DevID==id);
        }
        public async Task UploadDeveloperAsync(DevInfoDTO dev)
        {
dev.DevID=Guid.NewGuid();
            _context.Devs.Add(dev);
            await _context.SaveChangesAsync();
        }

        public Task<DevInfoUpdate> UpdateDeveloperAsync(Guid id, DevInfoUpdate updatedDev)
        {
            throw new NotImplementedException();
        }
    }
}
