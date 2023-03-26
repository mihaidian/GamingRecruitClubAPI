using Microsoft.AspNetCore.Mvc;

namespace GamingRecruitClubAPI.Controllers
{
    public class GameInfosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
