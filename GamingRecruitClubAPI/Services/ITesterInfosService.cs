using GamingRecruitClubAPI.DTOs;

namespace GamingRecruitClubAPI.Services
{
    public interface ITesterInfosService
    {
        public Task <IEnumerable<TesterInfoDTO>> GetTesterInfosAsync ();
        public Task <TesterInfoDTO> GetTesterInfoByIdAsync (Guid id);
        public Task UploadTesterAsync(TesterInfoDTO newTester);
    }
}
