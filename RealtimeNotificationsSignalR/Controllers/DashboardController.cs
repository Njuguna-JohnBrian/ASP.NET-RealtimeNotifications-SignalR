using Microsoft.AspNetCore.Mvc;

namespace RealtimeNotificationsSignalR.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}