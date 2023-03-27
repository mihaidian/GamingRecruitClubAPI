using GamingRecruitClubAPI.DTOs;

namespace GamingRecruitClubAPI.Repositories
{
    public interface ITesterInfosRepository
    {
        public Task<IEnumerable<TesterInfoDTO>> GetTesterInfosAsync();
        public Task <TesterInfoDTO> GetTesterInfoByIdAsync(Guid id);
    }
}
