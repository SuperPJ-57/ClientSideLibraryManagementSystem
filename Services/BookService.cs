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
        public async Task<bool> AddBookAsync(BooksEntity book,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var formData = new MultipartFormDataContent();

            formData.Add(new StringContent(book.Title), "Title");
            formData.Add(new StringContent(book.Genre), "Genre");
            formData.Add(new StringContent(book.AuthorId.ToString()), "AuthorId");
            formData.Add(new StringContent(book.ISBN), "ISBN");
            var response = await _httpClient.PostAsync("https://localhost:7084/api/Books", formData);

            // Return whether the API request was successful
            return response.IsSuccessStatusCode;
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
