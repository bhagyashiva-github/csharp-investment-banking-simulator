namespace Encapsulation
{
    using System;
    using System.IO;
    using NLog;

    internal class IBEncapsulation
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        // Private fields (Encapsulation)
        private string bankName;
        private double balance;
        private string accountHolder;

        // Constructor to initialize values
        public IBEncapsulation(string bankName, string accountHolder, double initialDeposit)
        {
            this.bankName = bankName;
            this.accountHolder = accountHolder;
            this.balance = initialDeposit > 0 ? initialDeposit : 0; // Ensuring valid initial deposit
            logger.Info($"Account created for {accountHolder} with initial balance: ${this.balance}");
        }

        // Public property to get bank name (Read-only)
        public string BankName => this.bankName;

        // Public property to get account holder name (Read-only)
        public string AccountHolder => this.accountHolder;

        // Public method to deposit money
        public void Deposit(double amount)
        {
            try
            {
                if (amount <= 0)
                    throw new ArgumentException("Deposit amount must be positive.");

                this.balance += amount;
                Console.WriteLine($"Deposit successful! New balance: ${this.balance}");
                logger.Info($"Deposited ${amount}. New balance: ${this.balance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                logger.Error(ex);
            }
        }

        // Public method to withdraw money with validation
        public void Withdraw(double amount)
        {
            try
            {
                if (amount <= 0)
                    throw new ArgumentException("Withdrawal amount must be positive.");
                if (amount > this.balance)
                    throw new InvalidOperationException("Insufficient funds.");

                this.balance -= amount;
                Console.WriteLine($"Withdrawal successful! New balance: ${this.balance}");
                logger.Info($"Withdrew ${amount}. New balance: ${this.balance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                logger.Error(ex);
            }
        }

        // Public method to check balance (Read-only)
        public double GetBalance()
        {
            logger.Info($"Balance checked: ${this.balance}");
            return this.balance;
        }
    }

    partial class Program
    {
        public static void ExecuteEncapsulation()
        {
            try
            {
                // Creating an InvestmentBank object
                IBEncapsulation myBank = new IBEncapsulation("Global Investments", "John Doe", 5000);

                // Displaying bank details
                Console.WriteLine($"Bank: {myBank.BankName}");
                Console.WriteLine($"Account Holder: {myBank.AccountHolder}");
                Console.WriteLine($"Initial Balance: ${myBank.GetBalance()}");

                // Performing transactions
                myBank.Deposit(2000);
                myBank.Withdraw(1500);
                myBank.Withdraw(6000); // Invalid withdrawal

                // Checking final balance
                Console.WriteLine($"Final Balance: ${myBank.GetBalance()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                // Flush and close loggers properly
                LogManager.Shutdown();
            }

        }
    }
}


