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
                        break;

                    case "3":
                        break;

                    case "4":
                        break;


                    default:
                        Console.WriteLine("Please select valid option");
                        break;
                }
            }


        }
    }
}
