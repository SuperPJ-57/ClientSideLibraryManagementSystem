using ClientSideLibraryManagementSystem.Models;
using Lms.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientSideLibraryManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStudentService _studentService;
        public StudentController(IHttpContextAccessor httpContextAccessor, IStudentService studentService)
        {
            _httpContextAccessor = httpContextAccessor;
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("JWToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Auth");
            }
            var response = _studentService.GetAllStudentsAsync(token).Result;
            var students = new StudentViewModel
            {
                Students = response
            };
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")  // Check if it's an AJAX request
            {
                return PartialView("_StudentPartial",students);
            }

            return View(students);
        }
        [Route("Student/StudentRegister")]
        public async Task<IActionResult> AddStudent(StudentsEntity student)
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
            var result = await _studentService.AddStudentAsync(student, token);
            if (!result)
            {
                ModelState.AddModelError("", "Error adding student.");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
