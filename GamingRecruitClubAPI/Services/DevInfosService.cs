using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
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

        public async Task UploadDeveloperAsync(DevInfoDTO newDev)
        {
            await _repository.UploadDeveloperAsync(newDev);
        }
        public async Task<DevInfoUpdate> UpdateDeveloperAsync(Guid id, DevInfoUpdate dev)
        {
            return await _repository.UpdateDeveloperAsync(id, dev);
        }

        public Task<DevInfoUpdate> UpdatePartiallyDeveloperAsync(Guid id, DevInfoUpdate dev)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteDeveloperAsync(Guid id)
        {
            return await _repository.DeleteDeveloperAsync(id);
        }
    }
}
