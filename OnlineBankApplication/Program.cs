using System;

namespace OnlineBankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********Welcome to the Bank**********");
            
            while(true)
            { 
            
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Print all Account");
            Console.WriteLine("5. Print all Transactions");

           
            var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting");
                        return;

                    case "1":
                        Console.WriteLine("Email Address");
                        var email = Console.ReadLine();

                        //Convert enum to array
                        Console.WriteLine("Account Type");
                        var accountTypes = Enum.GetNames(typeof(TypeOfAccounts));


                        //Loop through the array and print it
                        for(var i =0; i<accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {accountTypes[i]}"  );
                        }

                        var accountType =Enum.Parse<TypeOfAccounts>( Console.ReadLine());

                        Console.WriteLine("Initial Deposit");
                        var amount =Convert.ToDecimal( Console.ReadLine());


                        var account = Bank.CreateAccount(email, accountType, amount);
                        Console.WriteLine($"AN: {account.AccountNumber} ," +
                            $"EA: {account.EmailAddress}, " +
                            $"CD : {account.CreatedDate} , BAL: {account.Balance:C}, AT: {account.AccountType}");
                        break;

                    case "2":
                        PrintAllAccounts();
                        Console.WriteLine("Account Number");
                        var accountNumber = Convert.ToInt32( Console.ReadLine());

                        Console.WriteLine("Amount to Deposit");
                        amount = Convert.ToDecimal(Console.ReadLine());

                        Bank.Deposit(accountNumber, amount);
                        Console.WriteLine("Deposit Successfull");
                        break;

                    case "3":
                        PrintAllAccounts();
                        Console.WriteLine("Account Number");
                        accountNumber = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Amount to Withdraw");
                        amount = Convert.ToDecimal(Console.ReadLine());

                        Bank.Withdraw(accountNumber, amount);
                        Console.WriteLine("Withdrawl Successfull");

                        break;

                    case "4":
                        PrintAllAccounts();
                        break;

                    case "5":
                        PrintAllAccounts();
                        Console.WriteLine("Account Number");
                        accountNumber = Convert.ToInt32(Console.ReadLine());

                        var transactions = Bank.GetAllTransactionsByAccountNumber(accountNumber);

                        foreach(var transaction in transactions)
                        {
                            Console.WriteLine($"ID:{transaction.Id}, CD:{transaction.TransactionDate}, TT: {transaction.TransactionType}, Amount:{transaction.Amount:C}, AN:{transaction.AccountNumber}, Bal:{transaction.Balance:C}");
                        }

                        break;
                    default:
                        Console.WriteLine("Please select valid option");
                        break;
                }
            }


        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address");
            var emailAddress = Console.ReadLine();

            var accounts = Bank.GetAllAccountsByEmailAddress(emailAddress);

            foreach (var myAccount in accounts)
            {
                Console.WriteLine($"AN: {myAccount.AccountNumber} ," +
                $"EA: {myAccount.EmailAddress}, " +
                $"CD : {myAccount.CreatedDate} , BAL: {myAccount.Balance:C}, AT: {myAccount.AccountType}");
            }
        }
    }
}
