

using ClientSideLibraryManagementSystem.Models;

namespace ClientSideLibraryManagementSystem.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorsEntity>> GetAllAuthorsAsync();
        Task<AuthorsEntity> GetAuthorByIdAsync(int authorId);
        Task<AuthorsEntity> AddAuthorAsync(AuthorsEntity author);
        Task<AuthorsEntity> UpdateAuthorAsync(AuthorsEntity author);
        Task<bool> DeleteAuthorAsync(int authorId);
    }
}
