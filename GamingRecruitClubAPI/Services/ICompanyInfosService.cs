﻿using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
using GamingRecruitClubAPI.DTOs;

namespace GamingRecruitClubAPI.Services
{
    public interface ICompanyInfosService
    {
        public Task<IEnumerable<CompanyInfoDTO>> GetCompanyInfosAsync();
        public Task<CompanyInfoDTO> GetCompanyInfoByIdAsync(Guid id);
        public Task UploadCompanyAsync(CompanyInfoDTO newComp);
        public Task<CompanyInfoUpdate> UpdateCompanyAsync(Guid id, CompanyInfoUpdate comp);
        public Task<CompanyInfoUpdate> UpdatePartiallyCompanyAsync(Guid id, CompanyInfoUpdate comp);
        public Task<bool> DeleteCompanyAsync(Guid id);
    }
}
