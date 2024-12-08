﻿using ClientSideLibraryManagementSystem.Models;
using System.Net.Http.Headers;

namespace ClientSideLibraryManagementSystem.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _httpClient;

        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<AuthorsEntity> AddAuthorAsync(AuthorsEntity author)
        {
            throw new NotImplementedException();
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
