
namespace Inheritance

{
    using System;
    using NLog;

    // Base class
    public class ClientInvestmentAccount
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public string ClientName { get; set; }
        public decimal Balance { get; set; }

        public ClientInvestmentAccount(string name, decimal balance)

        {
            this.ClientName = name;
            this.Balance = balance;
        }

        public virtual void Invest(decimal amount)
        {
            if (amount > this.Balance)
                throw new InvalidOperationException("Insufficient balance for investment.");

            this.Balance -= amount;
            logger.Info($"{this.ClientName} invested {amount:C}. Remaining balance: {this.Balance:C}");
        }
    }

    // Derived class
    public class EquityInvestment : ClientInvestmentAccount
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public EquityInvestment(string name, decimal balance) : base(name, balance) { }


        public override void Invest(decimal amount)
        {
            logger.Info($"[Equity] Processing investment for {this.ClientName}");
            base.Invest(amount);
        }
    }

    // Another derived class
    public class BondInvestment : ClientInvestmentAccount
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public BondInvestment(string name, decimal balance) : base(name, balance) { }


        public override void Invest(decimal amount)
        {
            logger.Info($"[Bond] Processing investment for {this.ClientName}");
            base.Invest(amount);
        }
    }

    partial class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static void ExecuteInheritance()
        {
            try
            {
                ClientInvestmentAccount equityAccount = new EquityInvestment("Alex", 100000);
                equityAccount.Invest(50000);

                ClientInvestmentAccount bondAccount = new Inheritance.BondInvestment("Bob", 200000);
                bondAccount.Invest(120000);

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
