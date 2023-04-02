using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
using GamingRecruitClubAPI.Repositories;

namespace GamingRecruitClubAPI.Services
{
    public class TesterInfosService:ITesterInfosService
    {
        private readonly ITesterInfosRepository _repository; 
        public TesterInfosService(ITesterInfosRepository repository)
        {
            _repository = repository;
        }

        public async Task<TesterInfoDTO> GetTesterInfoByIdAsync(Guid id)
        {
            return await _repository.GetTesterInfoByIdAsync(id);
        }

        public async Task<IEnumerable<TesterInfoDTO>> GetTesterInfosAsync()
        {
            return await _repository.GetTesterInfosAsync();
        }

        public async Task UploadTesterAsync(TesterInfoDTO newTester)
        {
            await _repository.UploadTesterAsync(newTester);
        }
        public async Task<TesterInfoUpdate> UpdateTesterAsync(Guid id, TesterInfoUpdate tester)
        {
            return await _repository.UpdateTesterAsync(id, tester);
        }

        public Task<TesterInfoUpdate> UpdatePartiallyTesterAsync(Guid id, TesterInfoUpdate tester)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTesterAsync(Guid id)
        {
            return await _repository.DeleteTesterAsync(id);
        }
    }
}
