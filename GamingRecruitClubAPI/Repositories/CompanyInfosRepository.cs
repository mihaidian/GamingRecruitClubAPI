using AutoMapper;
using GamingRecruitClubAPI.DataContext;
using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
using Microsoft.EntityFrameworkCore;

namespace GamingRecruitClubAPI.Repositories
{
    public class CompanyInfosRepository:ICompanyInfosRepository
    {
        private readonly GamingClubDataContext _context;
        private readonly IMapper _mapper;
        public CompanyInfosRepository(GamingClubDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteCompanyAsync(Guid id)
        {
            CompanyInfoDTO comp= await GetCompanyInfoByIdAsync(id);
            if(comp == null) 
            {
                return false;
            }
            _context.Companies.Remove(comp);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<CompanyInfoDTO> GetCompanyInfoByIdAsync(Guid id)
        {
            return await _context.Companies.SingleOrDefaultAsync(a => a.CompanyId == id);
        }

        public async Task<IEnumerable<CompanyInfoDTO>> GetCompanyInfosAsync()
        {
           return await _context.Companies.ToListAsync();
        }
            public async Task<CompanyInfoUpdate> UpdateCompanyAsync(Guid id, CompanyInfoUpdate comp)
            {
                if (!await ExistCompanyAsync(id))
                {
                    return null;
                }
                var updatedComp = _mapper.Map<CompanyInfoDTO>(comp);
                updatedComp.CompanyId = id;
                _context.Update(updatedComp);
                await _context.SaveChangesAsync();
                return comp;
            }
        private async Task<bool> ExistCompanyAsync(Guid id)
        {
            return await _context.Companies.CountAsync(a => a.CompanyId == id) > 0;
        }

        public async Task<CompanyInfoUpdate> UpdatePartiallyCompanyAsync(Guid id, CompanyInfoUpdate comp)
        {
            var compFromDb= await GetCompanyInfoByIdAsync(id);
             if (!string.IsNullOrEmpty(comp.CompanyName) && comp.CompanyName != compFromDb.CompanyName)
            {
                compFromDb.CompanyName = comp.CompanyName;
            }
            if (comp.MemberSince.HasValue && comp.MemberSince != compFromDb.MemberSince)
            {
                compFromDb.MemberSince = comp.MemberSince;
            }
            _context.Companies.Update(compFromDb);
            await _context.SaveChangesAsync();
            return comp;
        }

        public async Task UploadCompanyAsync(CompanyInfoDTO newComp)
        {
            newComp.CompanyId = Guid.NewGuid();
            _context.Companies.Add(newComp);
            await _context.SaveChangesAsync();
        }
    }
}
