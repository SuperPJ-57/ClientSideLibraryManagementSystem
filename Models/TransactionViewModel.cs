﻿namespace ClientSideLibraryManagementSystem.Models
{
    public class TransactionViewModel
    {
        public TransactionsEntity Transaction { get; set; }
        public IEnumerable<TransactionsEntity> Transactions { get; set; }
    }
}
