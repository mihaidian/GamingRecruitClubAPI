using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;
using GamingRecruitClubAPI.Helpers;
using GamingRecruitClubAPI.Models;
using GamingRecruitClubAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GamingRecruitClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesterInfosController : Controller
    {
        
        private readonly ITesterInfosService _testerInfosService;
        private readonly ILogger<TesterInfosController> _logger;
        public TesterInfosController(ITesterInfosService testerInfosService, ILogger<TesterInfosController> logger)
        {
            _testerInfosService = testerInfosService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInfosAsync()
        {
            try
            {
                _logger.LogInformation("Getting all testers started...");
                var testers = await _testerInfosService.GetTesterInfosAsync();
                if(testers == null|| !testers.Any()) 
                {
                    return StatusCode((int)HttpStatusCode.NoContent,ErrorMessagesEnum.NoElementFound);
                }
                return Ok(testers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Getting all testers occured an error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllInfosByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Getting all testers by ID started...");
                var testers = await _testerInfosService.GetTesterInfoByIdAsync(id);
                if (testers == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(testers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Getting all testers by ID occured an error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UploadTesterAsync([FromBody] TesterInfoDTO newTester)
        {
            try
            {
                _logger.LogInformation(" Upload Tester started!");
                if (newTester == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _testerInfosService.UploadTesterAsync(newTester);
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
        public async Task<IActionResult> PutTester([FromRoute] Guid id, [FromBody] TesterInfoUpdate tester)
        {
            try
            {
                _logger.LogInformation("Update started");
                if (tester == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                TesterInfoUpdate updatedTester = await _testerInfosService.UpdateTesterAsync(id, tester);
                if (updatedTester == null)
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
        public async Task<IActionResult> DeleteTesterAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Delete Announcement started");
                bool result = await _testerInfosService.DeleteTesterAsync(id);
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
