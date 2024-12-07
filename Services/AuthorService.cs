using ClientSideLibraryManagementSystem.Models;

namespace ClientSideLibraryManagementSystem.Services
{
    public class AuthorService : IAuthorService
    {
        public Task<AuthorsEntity> AddAuthorAsync(AuthorsEntity author)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAuthorAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorsEntity>> GetAllAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorsEntity> GetAuthorByIdAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorsEntity> UpdateAuthorAsync(AuthorsEntity author)
        {
            throw new NotImplementedException();
        }
    }
}
