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
    public class GameInfosController : Controller
    {
        private readonly IGameInfosService _gameInfosService;
        private readonly ILogger<GameInfosController> _logger;
        public GameInfosController(IGameInfosService gameInfosService, ILogger<GameInfosController> logger)
        {
            _gameInfosService = gameInfosService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInfosAsync()
        {
            try
            {
                _logger.LogInformation("Getting all Games started...");
                var games = await _gameInfosService.GetGameInfosAsync();
                if(games == null || !games.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(games);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Getting all games occured an error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllInfosByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Getting all games by ID..");
                var games = await _gameInfosService.GetGameInfoByIdAsync(id);
                if (games == null)
                {
                    return NotFound( ErrorMessagesEnum.NoElementFound);
                }
                return Ok(games);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Getting all games by ID occured an error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UploadTesterAsync([FromBody] GameInfoDTO newGame)
        {
            try
            {
                _logger.LogInformation(" Upload Game started!");
                if (newGame == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _gameInfosService.UploadGameAsync(newGame);
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
        public async Task<IActionResult> PutGame([FromRoute] Guid id, [FromBody] GameInfoUpdate game)
        {
            try
            {
                _logger.LogInformation("Update started");
                if (game == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                GameInfoUpdate updatedGame = await _gameInfosService.UpdateGameAsync(id, game);
                if (updatedGame == null)
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
        public async Task<IActionResult> PatchtGame([FromRoute] Guid id, [FromBody] GameInfoUpdate game)
        {
            try
            {
                _logger.LogInformation("Update started");
                if (game == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                GameInfoUpdate updatedGame = await _gameInfosService.UpdatePartiallyGameAsync(id, game);
                if (updatedGame == null)
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
        public async Task<IActionResult> DeleteGameAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Delete Game started");
                bool result = await _gameInfosService.DeleteGameAsync(id);
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
