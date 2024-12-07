using ClientSideLibraryManagementSystem.Models;

namespace ClientSideLibraryManagementSystem.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionsEntity>> GetAllTransactionsAsync();
        Task<TransactionsEntity> GetTransactionByIdAsync(int authorId);
        Task<TransactionsEntity> AddTransactionAsync(TransactionsEntity author);
        Task<TransactionsEntity> UpdateTransactionAsync(TransactionsEntity author);
        Task<bool> DeleteTransactionAsync(int authorId);
    }
}
