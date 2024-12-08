using ClientSideLibraryManagementSystem.Models;

namespace ClientSideLibraryManagementSystem.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BooksEntity>> GetAllBooksAsync(string token);
        Task<BooksEntity> GetBookByIdAsync(int bookId);
        Task<BooksEntity> AddBookAsync(BooksEntity book);
        Task<BooksEntity> UpdateBookAsync(BooksEntity book);
        Task<bool> DeleteBookAsync(int bookId);
    }
}
