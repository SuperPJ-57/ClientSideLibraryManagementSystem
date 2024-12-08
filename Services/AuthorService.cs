using ClientSideLibraryManagementSystem.Models;
using System.Net.Http.Headers;
using System.Transactions;

namespace ClientSideLibraryManagementSystem.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _httpClient;

        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddAuthorAsync(AuthorsEntity author,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            var formData = new MultipartFormDataContent();

            formData.Add(new StringContent(author.Name), "Name");
            formData.Add(new StringContent(author.Bio), "Bio");
            var response = await _httpClient.PostAsync("https://localhost:7084/api/Authors", formData);

            // Return whether the API request was successful
            return response.IsSuccessStatusCode;
        }

        public Task<bool> DeleteAuthorAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AuthorsEntity>> GetAllAuthorsAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("https://localhost:7084/api/Authors");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<AuthorsEntity>>();
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
