using ClientSideLibraryManagementSystem.Models;
using ClientSideLibraryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientSideLibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBookService _bookService;
        public BookController(IHttpContextAccessor httpContextAccessor, IBookService bookService)
        {
            _httpContextAccessor = httpContextAccessor;
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(token))
            {
                // If no token is present, redirect to login
                return RedirectToAction("Login", "Auth");
            }
            var books = _bookService.GetAllBooksAsync(token).Result;
            var bookmodel = new BookViewModel
            {
                Books = books
            };
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")  // Check if it's an AJAX request
            {
                return PartialView("_BookPartial", bookmodel);
            }
            return View(bookmodel);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookModel model)
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
            var book = new BooksEntity
            {
                Title = model.Title,
                Genre = model.Genre,
                AuthorId = model.AuthorId,
                ISBN = model.ISBN
            };
            var result = await _bookService.AddBookAsync(book, token);
            if (!result)
            {
                ModelState.AddModelError("", "Error adding book.");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
