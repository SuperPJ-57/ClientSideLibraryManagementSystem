using ClientSideLibraryManagementSystem.Models;

namespace ClientSideLibraryManagementSystem.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BooksEntity>> GetAllBooksAsync(string token);
        Task<BooksEntity> GetBookByIdAsync(int bookId);
        Task<bool> AddBookAsync(BooksEntity book,string token);
        Task<BooksEntity> UpdateBookAsync(BooksEntity book);
        Task<bool> DeleteBookAsync(int bookId);
    }
}
