using GamingRecruitClubAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
