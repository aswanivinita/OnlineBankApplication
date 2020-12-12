using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBankApplication
{
    enum TypeOfAccounts
    {
        Checkings,
        Savings,
        CD,
        Loan
    }
    class Account
    {
        private static int lastAccountNumber = 0;
        #region Properties
        public string EmailAddress { get; set; }
        public int AccountNumber { get; }
        public TypeOfAccounts AccountType { get; set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedDate { get; private set; }

        #endregion

        #region Constructor
        public Account()
        {
            AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.Now;
        }

        #endregion

        #region Methods

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        

        #endregion

    }
}