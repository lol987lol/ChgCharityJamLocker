using System.Diagnostics;
using LockerOpener.Models;
using LockerOpener.Services;
using Microsoft.AspNetCore.Mvc;

namespace LockerOpener.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LockerClient _lockerClient;

        public HomeController(ILogger<HomeController> logger, LockerClient lockerClient)
        {
            _logger = logger;
            _lockerClient = lockerClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> OpenLocker()
        {
            await _lockerClient.OpenLocker("1");
            return RedirectToAction(nameof(Index));
        }
    }
}
