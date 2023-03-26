using GamingRecruitClubAPI.DTOs;

namespace GamingRecruitClubAPI.Services
{
    public interface IDevInfosService
    {
        public Task<IEnumerable<DevInfoDTO>> GetDevInfosAsync();
        public Task<DevInfoDTO> GetDevInfoByIdAsync(Guid id);
    }
}
