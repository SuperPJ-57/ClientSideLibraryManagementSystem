using ClientSideLibraryManagementSystem.Models;

namespace Lms.Domain.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentsEntity>> GetAllStudentsAsync();
        Task<StudentsEntity> GetStudentByIdAsync(int studentId);
        Task<StudentsEntity> AddStudentAsync(StudentsEntity student);
        Task<bool> UpdateStudentAsync(StudentsEntity student);
        Task DeleteStudentAsync(int studentId);
    }
}
