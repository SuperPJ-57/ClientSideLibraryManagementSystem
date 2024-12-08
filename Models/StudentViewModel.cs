namespace ClientSideLibraryManagementSystem.Models
{
    public class StudentViewModel
    {
        public StudentsEntity Student { get; set; } = null;
        public IEnumerable<StudentsEntity> Students { get; set; }
    }
}
