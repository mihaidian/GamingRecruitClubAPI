using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.Repositories;

namespace GamingRecruitClubAPI.Services
{
    public class DevInfosService:IDevInfosService
    {
        private readonly IDevInfosRepository _repository;
        public DevInfosService(IDevInfosRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<DevInfoDTO>> GetDevInfosAsync()
        {
            return await _repository.GetDevInfosAsync(); 
        }
        public async Task<DevInfoDTO> GetDevInfoByIdAsync(Guid id)
        {
            return await _repository.GetDevInfoByIdAsync(id);
        }

        public async Task UploadDeveloperAsync(DevInfoDTO newdev)
        {
            await _repository.UploadDeveloperAsync(newdev);
        }
    }
}
