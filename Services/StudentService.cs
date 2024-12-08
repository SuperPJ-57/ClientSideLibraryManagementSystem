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
        public async Task<bool> AddStudentAsync(StudentsEntity student, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var formData = new MultipartFormDataContent();

            formData.Add(new StringContent(student.Name), "Name");
            formData.Add(new StringContent(student.Email), "Email");
            formData.Add(new StringContent(student.ContactNumber), "ContactNumber");
            formData.Add(new StringContent(student.Department), "Department");

            var response = await _httpClient.PostAsync("https://localhost:7084/api/Students", formData);

            return response.IsSuccessStatusCode;
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
