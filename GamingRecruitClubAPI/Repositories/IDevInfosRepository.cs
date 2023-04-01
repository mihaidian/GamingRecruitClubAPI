using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;

namespace GamingRecruitClubAPI.Repositories
{
    public interface IDevInfosRepository
    {
        public Task <IEnumerable<DevInfoDTO>> GetDevInfosAsync();
        public Task<DevInfoDTO> GetDevInfoByIdAsync(Guid id);
        public Task UploadDeveloperAsync(DevInfoDTO newDev);
        public Task<DevInfoUpdate> UpdateDeveloperAsync(Guid id, DevInfoUpdate updatedDev);
    }
}
