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

        [HttpGet("users/{id}")]
        public IActionResult Index([FromRoute] string id)
        {
            var model = new UsersViewModel { Id = id };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> OpenLocker([FromForm] string lockerId)
        {
            await _lockerClient.OpenLocker(lockerId);
            return RedirectToAction(nameof(Done));
        }

        public IActionResult Done()
        {
            return View();
        }
    }
}
