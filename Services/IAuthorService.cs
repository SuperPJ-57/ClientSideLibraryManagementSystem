

using ClientSideLibraryManagementSystem.Models;

namespace ClientSideLibraryManagementSystem.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorsEntity>> GetAllAuthorsAsync(string token);
        Task<AuthorsEntity> GetAuthorByIdAsync(int authorId);
        Task<bool> AddAuthorAsync(AuthorsEntity author,string token);
        Task<AuthorsEntity> UpdateAuthorAsync(AuthorsEntity author);
        Task<bool> DeleteAuthorAsync(int authorId);
    }
}
