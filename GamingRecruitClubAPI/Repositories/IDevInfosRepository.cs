using GamingRecruitClubAPI.DTOs;

namespace GamingRecruitClubAPI.Repositories
{
    public interface IDevInfosRepository
    {
        public Task <IEnumerable<DevInfoDTO>> GetDevInfosAsync();
        public Task<DevInfoDTO> GetDevInfoByIdAsync(Guid id);

    }
}
