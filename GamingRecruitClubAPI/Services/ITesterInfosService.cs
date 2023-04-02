using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;

namespace GamingRecruitClubAPI.Services
{
    public interface ITesterInfosService
    {
        public Task <IEnumerable<TesterInfoDTO>> GetTesterInfosAsync ();
        public Task <TesterInfoDTO> GetTesterInfoByIdAsync (Guid id);
        public Task UploadTesterAsync(TesterInfoDTO newTester);
        public Task <TesterInfoUpdate> UpdateTesterAsync(Guid id, TesterInfoUpdate tester);
        public Task<TesterInfoUpdate> UpdatePartiallyTesterAsync(Guid id, TesterInfoUpdate tester);
        public Task<bool> DeleteTesterAsync(Guid id);
    }
}
