using LockerOpener.Models;
using LockerOpener.Services;
using Microsoft.AspNetCore.Mvc;

namespace LockerOpener.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly LockerClient _lockerClient;

        public UsersController(ILogger<UsersController> logger, LockerClient lockerClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _lockerClient = lockerClient ?? throw new ArgumentNullException(nameof(lockerClient));
        }

        public IActionResult Index(string id)
        {
            var model = new UsersViewModel { Id = id };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> OpenLocker([FromForm] string id)
        {
            await _lockerClient.OpenLocker(id);
            return RedirectToAction(nameof(Done));
        }

        public IActionResult Done()
        {
            return View();
        }
    }
}
