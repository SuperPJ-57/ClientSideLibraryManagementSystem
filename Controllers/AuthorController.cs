using ClientSideLibraryManagementSystem.Models;
using ClientSideLibraryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClientSideLibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorService _authorService;

        public AuthorController(IHttpContextAccessor httpContextAccessor, IAuthorService authorService)
        {
            _httpContextAccessor = httpContextAccessor;
            _authorService = authorService;
        }
        public IActionResult Index()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(token))
            {
                // If no token is present, redirect to login
                return RedirectToAction("Login", "Auth");
            }
            var authors = _authorService.GetAllAuthorsAsync(token).Result;
            var authormodel = new AuthorViewModel
            {
                Authors = authors,
                Author = null
            };
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")  // Check if it's an AJAX request
            {
                return PartialView("_AuthorPartial", authormodel);
            }
            return View(authormodel);
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorsEntity author)
        { // Add your logic to save the author to the database
            return RedirectToAction("Index");
        }
    }
}
