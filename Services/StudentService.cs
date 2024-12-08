using ClientSideLibraryManagementSystem.Models;
using Lms.Domain.Interfaces;
using System.Net.Http.Headers;

namespace ClientSideLibraryManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;
        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<bool> AddStudentAsync(StudentsEntity student, string token)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStudentAsync(int studentId)
        {
            throw new NotImplementedException();
        }

       
        public async Task<IEnumerable<StudentsEntity>> GetAllStudentsAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("https://localhost:7084/api/Students");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<StudentsEntity>>();
        }

        public Task<StudentsEntity> GetStudentByIdAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStudentAsync(StudentsEntity student)
        {
            throw new NotImplementedException();
        }
    }
}
