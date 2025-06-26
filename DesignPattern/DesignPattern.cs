namespace DesignPatterns
{
    using System;
    using System.Collections.Generic;


    // Factory pattern: Common interface for investments
    public interface IInvestment
    {
        string Name { get; }
        double Amount { get; }
        double CalculateReturns();
    }

    // Concrete Product: Stock
    public class Stock : IInvestment
    {
        public string Name => "Stock";
        public double Amount { get; private set; }
        public Stock(double amount) => Amount = amount;
        public double CalculateReturns() => Amount * 0.12;
    }

    // Concrete Product: Bond
    public class Bond : IInvestment
    {
        public string Name => "Bond";
        public double Amount { get; private set; }
        public Bond(double amount) => Amount = amount;
        public double CalculateReturns() => Amount * 0.05;
    }

    // Factory pattern implementation
    public static class InvestmentFactory
    {
        public static IInvestment CreateInvestment(string type, double amount)
        {
            return type.ToLower() switch
            {
                "stock" => new Stock(amount),
                "bond" => new Bond(amount),
                _ => throw new ArgumentException($"Unknown investment type: {type}")
            };
        }
    }

    // Observer interface
    public interface IObserver
    {
        void Update(string message);
    }

    // Subject interface
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string message);
    }

    // Subject implementation: Market alerts
    public class MarketNotification : ISubject
    {
        private readonly List<IObserver> _observers = new();
        public void Attach(IObserver observer) => _observers.Add(observer);
        public void Detach(IObserver observer) => _observers.Remove(observer);
        public void Notify(string message)
        {
            foreach (var observer in _observers)
                observer.Update(message);
        }
    }

    // Observer implementation: Client receives updates
    public class InvestmentClient : IObserver
    {
        public string ClientName { get; }
        public InvestmentClient(string name) => ClientName = name;
        public void Update(string message) =>
            Console.WriteLine($"[Notification to {ClientName}]: {message}");
    }

    // Singleton Logger
    public sealed class Logger
    {
        private static readonly Lazy<Logger> _instance = new(() => new Logger());
        public static Logger Instance => _instance.Value;
        private Logger() { }

        public void Log(string message) =>
            Console.WriteLine($"[LOG]: {DateTime.Now:G}: {message}");
    }

    // Repository to manage investments
    public class InvestmentRepository
    {
        private readonly List<IInvestment> _investments = new();
        public void Add(IInvestment investment) => _investments.Add(investment);
        public IEnumerable<IInvestment> GetAll() => _investments;
    }

    // Entry point
    partial class Program
    {
        public static void ExecuteDesignPatterns()
        {
            Console.WriteLine("Inside Main method of design patterns.cs");
            var logger = Logger.Instance;

            var repository = new InvestmentRepository();
            var notifier = new MarketNotification();

            // Attach clients for notification updates
            var client = new InvestmentClient("John");
            notifier.Attach(client);

            try
            {
                // Create and store investments using the Factory
                var investments = new[]
                {
                InvestmentFactory.CreateInvestment("stock", 10000),
                InvestmentFactory.CreateInvestment("bond", 5000)
            };

                foreach (var inv in investments)
                {
                    repository.Add(inv);
                    double returns = inv.CalculateReturns();
                    logger.Log($"Processed {inv.Name} (${inv.Amount}): Expected Return = ${returns}");
                    notifier.Notify($"{inv.Name} updated! Returns: ${returns}");
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Exception: {ex.Message}");
                Console.WriteLine("Something went wrong. Check the logs above.");
            }
        }
    }


}


