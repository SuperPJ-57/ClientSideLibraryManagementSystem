namespace ClientSideLibraryManagementSystem.Models
{
    public class AuthorViewModel
    {
        public AuthorsEntity Author { get; set; }
        public AddAuthorModel AddAuthorModel { get; set; }
        public IEnumerable<AuthorsEntity> Authors{ get; set; }
    }
}
