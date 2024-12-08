using ClientSideLibraryManagementSystem.Models;

namespace ClientSideLibraryManagementSystem.Services
{
    public interface IUserService
    {
        
        Task<IEnumerable<UsersEntity>> GetAllUsersAsync();
        Task<UsersEntity> GetUserByIdAsync(int userId);
        Task<bool> AddUserAsync(UsersEntity user);
        Task UpdateUserAsync(UsersEntity user);
        Task DeleteUserAsync(int userId);
    }
}
