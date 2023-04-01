using GamingRecruitClubAPI.DTOs;
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
    }
}
