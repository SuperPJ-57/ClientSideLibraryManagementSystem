using ClientSideLibraryManagementSystem.Models;

namespace ClientSideLibraryManagementSystem.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionsEntity>> GetAllTransactionsAsync(string token);
        Task<TransactionsEntity> GetTransactionByIdAsync(int transactionId);
        Task<bool> AddTransactionAsync(TransactionsEntity transaction,string token);
        Task<TransactionsEntity> UpdateTransactionAsync(TransactionsEntity transaction);
        Task<bool> DeleteTransactionAsync(int transactionId);
    }
}
