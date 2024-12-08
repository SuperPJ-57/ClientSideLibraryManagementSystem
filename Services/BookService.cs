using ClientSideLibraryManagementSystem.Models;
using System.Net.Http.Headers;
using System.Net.Http;

namespace ClientSideLibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<BooksEntity>> GetAllBooksAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("https://localhost:7084/api/Books");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<BooksEntity>>();
        }
        public Task<BooksEntity> AddBookAsync(BooksEntity book)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBookAsync(int bookId)
        {
            throw new NotImplementedException();
        }


        public Task<BooksEntity> GetBookByIdAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<BooksEntity> UpdateBookAsync(BooksEntity book)
        {
            throw new NotImplementedException();
        }
    }
}
