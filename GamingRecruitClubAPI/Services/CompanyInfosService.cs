using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
using GamingRecruitClubAPI.Repositories;

namespace GamingRecruitClubAPI.Services
{
    public class CompanyInfosService : ICompanyInfosService
    {
        private readonly ICompanyInfosRepository _repository;
        public CompanyInfosService(ICompanyInfosRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> DeleteCompanyAsync(Guid id)
        {
            return await _repository.DeleteCompanyAsync(id);
        }

        public async Task<CompanyInfoDTO> GetCompanyInfoByIdAsync(Guid id)
        {
           return await _repository.GetCompanyInfoByIdAsync(id);
        }

        public async Task<IEnumerable<CompanyInfoDTO>> GetCompanyInfosAsync()
        {
            return await _repository.GetCompanyInfosAsync();
        }

        public async Task<CompanyInfoUpdate> UpdateCompanyAsync(Guid id, CompanyInfoUpdate comp)
        {
            return await _repository.UpdateCompanyAsync(id, comp);
        }

        public async Task<CompanyInfoUpdate> UpdatePartiallyCompanyAsync(Guid id, CompanyInfoUpdate comp)
        {
            return await _repository.UpdatePartiallyCompanyAsync(id, comp);
        }

        public async Task UploadCompanyAsync(CompanyInfoDTO newComp)
        {
            await _repository.UploadCompanyAsync(newComp);
        }
    }
}
