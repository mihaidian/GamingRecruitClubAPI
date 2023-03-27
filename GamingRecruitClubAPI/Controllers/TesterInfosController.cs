using GamingRecruitClubAPI.Services;
using Microsoft.AspNetCore.Mvc;

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

    }
}
