using ClientSideLibraryManagementSystem.Models;
using ClientSideLibraryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientSideLibraryManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLoginModel)
        {
            if (ModelState.IsValid)
            {
                // Authenticate and retrieve the token
                string token = await _authService.AuthenticateAsync(userLoginModel);

                if (!string.IsNullOrEmpty(token))
                {
                    // Store the token in session
                    HttpContext.Session.SetString("JWToken", token);

                    // Redirect to the dashboard on successful login
                    return RedirectToAction("Index","Author");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(userLoginModel);
        }
    }
}
