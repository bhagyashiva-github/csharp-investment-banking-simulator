namespace TaskParallelLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using NLog;

    // Common interface for all investment types
    public interface IInvestment
    {
        string Name { get; }
        double Amount { get; }
        double CalculateReturns();
    }

    // Concrete class: Stocks
    public class Stock : IInvestment
    {
        public string Name => "Stocks";
        public double Amount { get; private set; }

        public Stock(double amount) => Amount = amount;
        public double CalculateReturns() => Amount * 0.12;
    }

    // Concrete class: Bonds
    public class Bond : IInvestment
    {
        public string Name => "Bonds";
        public double Amount { get; private set; }

        public Bond(double amount) => Amount = amount;
        public double CalculateReturns() => Amount * 0.05;
    }

    // Concrete class: Crypto
    public class Crypto : IInvestment
    {
        public string Name => "Crypto";
        public double Amount { get; private set; }

        public Crypto(double amount) => Amount = amount;
        public double CalculateReturns() => Amount * 0.2;
    }

    partial class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void ExecuteTaskParallel()
        {
            Console.WriteLine("Inside Main method of taskparallel.cs");
            logger.Info("Investment simulation started.");

            var investments = new List<IInvestment>
        {
            new Stock(10000),
            new Bond(5000),
            new Crypto(7000),
            new Stock(15000),
            new Bond(2000)
        };

            try
            {
                //Run investment evaluations in parallel
                Parallel.ForEach(investments, investment =>
                {
                    try
                    {
                        logger.Info($"Evaluating {investment.Name} investment: ${investment.Amount}");
                        var returns = investment.CalculateReturns();
                        Console.WriteLine($"{investment.Name}: Invested ${investment.Amount}, Expected Returns: ${returns}");
                        logger.Info($"{investment.Name} calculated successfully.");
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, $"Error processing {investment.Name}");
                    }
                });
            }
            catch (AggregateException ae)
            {
                foreach (var ex in ae.InnerExceptions)
                    logger.Error(ex, "Aggregate Exception encountered");
            }
            finally
            {
                logger.Info("Simulation complete.");
                LogManager.Shutdown(); // flush and close
            }

            /*
            Example using Parallel.For in C# 
            Runs a loop in parallel across the accountBalances array. Simulates applying a fixed interest rate to each balance.
            Outputs the updated values concurrently 
            */

            double[] accountBalances = { 10000, 25000, 5000, 32000, 18000 };

            // Apply interest in parallel using Parallel.For
            Parallel.For(0, accountBalances.Length, i =>
            {
                double interestRate = 0.07; // 7% annual return
                double interest = accountBalances[i] * interestRate;

                accountBalances[i] += interest;

                Console.WriteLine($"Account {i + 1}: Updated Balance = {accountBalances[i]:C}");
            });

            Console.WriteLine("All investments have been updated in parallel.");

        }
    }
}


