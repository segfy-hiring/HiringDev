using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YoutubeAPI.Business.Interfaces;
using YoutubeAPI.Business.Util;

namespace YoutubeApi.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        // POST: Account
        [HttpPost]
        public async Task<IActionResult> Login(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                await this.userService.GetUserByEmail(email);
                HttpContext.Session.SetString(Constants.USER, email);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(Constants.USER);
            HttpContext.Session.Remove(Constants.SEARCHES);
            HttpContext.Session.Remove(Constants.SEARCH);

            return RedirectToAction("Index", "Home");
        }
    }
}
