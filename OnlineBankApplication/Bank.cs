using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBankApplication
{
    static class Bank
    {
        private static BankContext db = new BankContext();
        public static Account CreateAccount(string emailAddress, TypeOfAccounts accountType, decimal initialDeposit)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType

            };
            if(initialDeposit >0)
            {
                account.Deposit(initialDeposit);
            }

            db.Accounts.Add(account);
            db.SaveChanges();

            return account;

        }

        public static IEnumerable<Account> GetAllAccountsByEmailAddress(string emailAddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static IEnumerable<Transaction> GetAllTransactionsByAccountNumber(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate) ;
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account= db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

            if(account ==null)
            {
                //throw exception later
                return;
            }

            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionType = TypeOfTransaction.Credit,
                Amount = amount,
                Description = "Bank Deposit",
                Balance = account.Balance,
                AccountNumber = account.AccountNumber
                
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

            if (account == null)
            {
                //throw exception later
                return;
            }

            account.Withdraw(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionType = TypeOfTransaction.Debit,
                Amount = amount,
                Description = "Bank Withdrawl",
                Balance = account.Balance,
                AccountNumber = account.AccountNumber

            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
    }
}
