using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBankApplication
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Transaction> transactions = new List<Transaction>();
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

            accounts.Add(account);

            return account;

        }

        public static IEnumerable<Account> GetAllAccountsByEmailAddress(string emailAddress)
        {
            return accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            var account= accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

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

            transactions.Add(transaction);
        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

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

            transactions.Add(transaction);
        }
    }
}
