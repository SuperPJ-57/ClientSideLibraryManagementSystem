using ClientSideLibraryManagementSystem.Models;
using ClientSideLibraryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

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
            var authors = _authorService.GetAllAuthorsAsync().Result;
            return View(authors);
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorsEntity author)
        { // Add your logic to save the author to the database
            return RedirectToAction("Index");
        }
    }
}
