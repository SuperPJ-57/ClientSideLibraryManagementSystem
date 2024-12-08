using ClientSideLibraryManagementSystem.Models;
using ClientSideLibraryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
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
        public async Task<IActionResult> AddAuthor(AddAuthorModel model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("JWToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Auth");
            }
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Index");
            }
            var author = new AuthorsEntity
            {
                Name = model.Name,
                Bio = model.Bio
            };
            var result = await _authorService.AddAuthorAsync(author, token);
            if (!result)
            {
                ModelState.AddModelError("", "Error adding author.");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
