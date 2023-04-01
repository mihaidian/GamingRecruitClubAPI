using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;

namespace GamingRecruitClubAPI.Repositories
{
    public interface ITesterInfosRepository
    {
        public Task<IEnumerable<TesterInfoDTO>> GetTesterInfosAsync();
        public Task <TesterInfoDTO> GetTesterInfoByIdAsync(Guid id);
        public Task UploadTesterAsync(TesterInfoDTO tester);
        public Task <TesterInfoUpdate> UpdateTesterAsync(Guid id,TesterInfoUpdate  tester);
    }
}
