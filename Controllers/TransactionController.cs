using ClientSideLibraryManagementSystem.Models;
using ClientSideLibraryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace ClientSideLibraryManagementSystem.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITransactionService _transactionService;
        public TransactionController(IHttpContextAccessor httpContextAccessor, ITransactionService transactionService)
        {
            _httpContextAccessor = httpContextAccessor;
            _transactionService = transactionService;
        }
        public IActionResult Index()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("JWToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Auth");
            }
            //if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")  // Check if it's an AJAX request
            //{
            //    return PartialView("_TransactionPartial");
            //}

            return View();
        }
        [Route("Transaction/TransactionRegister")]
        [HttpPost]
        public async Task<IActionResult> AddTransaction(AddTransactionModel model)
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
            var transac = new TransactionsEntity
            {
                StudentId = model.StudentId,
                UserId = model.UserId,
                BookId = model.BookId,
                BarCode = model.BarCode,
                TransactionType = model.TransactionType,
                Date = model.Date
            };
            var result = await _transactionService.AddTransactionAsync(transac, token);
            if (!result)
            {
                ModelState.AddModelError("", "Error adding transaction.");
                return RedirectToAction("Index");
            }
            return RedirectToAction("GetTransactions");
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("JWToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Auth");
            }
            var response = await _transactionService.GetAllTransactionsAsync(token);
            //if(type != null)
            //{
            //    response = response.Where(x => x.TransactionType == type).ToList();
            //}
            var transactions = new TransactionViewModel
            {
                Transactions = response
            };
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")  // Check if it's an AJAX request
            {
                return PartialView("_GetTransactionsPartial", transactions);
            }

            return View(transactions);
        }
    }
}
