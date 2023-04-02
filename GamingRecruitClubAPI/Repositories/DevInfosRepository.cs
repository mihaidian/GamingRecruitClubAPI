using AutoMapper;
using GamingRecruitClubAPI.DataContext;
using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace GamingRecruitClubAPI.Repositories
{
    public class DevInfosRepository:IDevInfosRepository
    {
        private readonly GamingClubDataContext _context;
        private readonly IMapper _mapper;
            public DevInfosRepository(GamingClubDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DevInfoDTO>> GetDevInfosAsync()
        {
            return await _context.Devs.ToListAsync();
        }
        public async Task<DevInfoDTO> GetDevInfoByIdAsync(Guid id)
        {
            return await _context.Devs.SingleOrDefaultAsync(a=>a.DevID==id);
        }
        public async Task UploadDeveloperAsync(DevInfoDTO newDev)
        {
newDev.DevID=Guid.NewGuid();
            _context.Devs.Add(newDev);
            await _context.SaveChangesAsync();
        }

        public async Task<DevInfoUpdate> UpdateDeveloperAsync(Guid id, DevInfoUpdate dev)
        {
            if (!await ExistDeveloperAsync(id))
            {
                return null;
            }
            var updatedDev=_mapper.Map<DevInfoDTO>(dev);
            updatedDev.DevID=id;
            _context.Update(updatedDev);
            await _context.SaveChangesAsync();
            return dev;
        }
        private async Task<bool> ExistDeveloperAsync(Guid id)
        {
            return await _context.Devs.CountAsync(a=>a.DevID==id) > 0;
        }

        public async Task<DevInfoUpdate> UpdatePartiallyDeveloperAsync(Guid id, DevInfoUpdate dev)
        {
            var devFromDb= await GetDevInfoByIdAsync(id);
            if(devFromDb==null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(dev.FirstName) && dev.FirstName != devFromDb.FirstName)
            {
                devFromDb.FirstName = dev.FirstName;
            }
            if (!string.IsNullOrEmpty(dev.LastName) && dev.LastName != devFromDb.LastName)
            {
                devFromDb.LastName = dev.LastName;
            }
            _context.Devs.Update(devFromDb);
            await _context.SaveChangesAsync();
            return dev;
        }

        public async Task<bool> DeleteDeveloperAsync(Guid id)
        {
            DevInfoDTO dev= await GetDevInfoByIdAsync(id);
if (dev==null)
            {
                return false;
            }
_context.Devs.Remove(dev);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
