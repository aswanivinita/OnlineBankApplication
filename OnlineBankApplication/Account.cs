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
        #region Properties
        public string EmailAddress { get; set; }
        public int AccountNumber { get; set; }
        public TypeOfAccounts AccountType { get; set; }
        public decimal Balance { get;  set; }
        public DateTime CreatedDate { get;  set; }

        #endregion

        #region Constructor
        public Account()
        {
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