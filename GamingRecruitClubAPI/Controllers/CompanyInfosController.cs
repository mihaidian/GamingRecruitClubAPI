using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.Helpers;
using GamingRecruitClubAPI.Models;
using GamingRecruitClubAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GamingRecruitClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyInfosController : Controller
    {
        private readonly ICompanyInfosService _compService;
        private readonly ILogger<CompanyInfosController> _logger;
        public CompanyInfosController(ICompanyInfosService compService, ILogger<CompanyInfosController> logger)
        {
            _compService = compService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompaniesAsync()
        {
            try
            {
                _logger.LogInformation("Getting all verified Companies...");
                var comps = await _compService.GetCompanyInfosAsync();
                if (comps == null || !comps.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(comps);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Getting all verified Companies occured an error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompaniesById([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Getting all verified Companies by ID...");
                var comps = await _compService.GetCompanyInfoByIdAsync(id);
                if (comps == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(comps);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Getting all Companies by ID occured an error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UploadCompanyAsync([FromBody] CompanyInfoDTO newComp)
        {
            try
            {
                _logger.LogInformation(" Upload Verified Company started!");
                if (newComp == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _compService.UploadCompanyAsync(newComp);
                return Ok(SuccesMessagesEnum.ElementSuccesfullyCreated);
            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception error: {ex.Message}");
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Validation exception error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany([FromRoute] Guid id, [FromBody] CompanyInfoUpdate comp)
        {
            try
            {
                _logger.LogInformation("Update verified Company started");
                if (comp == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                CompanyInfoUpdate updatedComp = await _compService.UpdateCompanyAsync(id, comp);
                if (updatedComp == null)
                {
                    return StatusCode((int)(HttpStatusCode.NoContent), ErrorMessagesEnum.NoElementFound);

                }
                return Ok(SuccesMessagesEnum.ElementSuccesfullyUpdated);
            }

            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception error: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Validation exception error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }

        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCompany([FromRoute] Guid id, [FromBody] CompanyInfoUpdate comp)
        {
            try
            {
                _logger.LogInformation("Update verified Company  started");
                if (comp == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                CompanyInfoUpdate updatedComp = await _compService.UpdatePartiallyCompanyAsync(id, comp);
                if (updatedComp == null)
                {
                    return StatusCode((int)(HttpStatusCode.NoContent), ErrorMessagesEnum.NoElementFound);

                }
                return Ok(SuccesMessagesEnum.ElementSuccesfullyUpdated);
            }

            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception error: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Validation exception error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Delete verified Company started");
                bool result = await _compService.DeleteCompanyAsync(id);
                if (result)
                {
                    return Ok(SuccesMessagesEnum.ElementSuccesfullyDeleted);
                }
                return BadRequest(ErrorMessagesEnum.NoElementFound);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Validation exception error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
    }

}
