using ClientSideLibraryManagementSystem.Models;

namespace ClientSideLibraryManagementSystem.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentsEntity>> GetAllStudentsAsync();
        Task<StudentsEntity> GetStudentByIdAsync(int authorId);
        Task<StudentsEntity> AddStudentAsync(StudentsEntity author);
        Task<StudentsEntity> UpdateStudentAsync(StudentsEntity author);
        Task<bool> DeleteStudentAsync(int authorId);
    }
}
