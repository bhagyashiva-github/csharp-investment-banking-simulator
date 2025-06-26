using System;
using System.Collections.Generic;
using NLog;

namespace Polymorphism
{
    // Abstract base class representing an investment
    abstract class Investment
    {
        // Common properties for all investments
        public string Name { get; set; }
        public double Amount { get; set; }

        // Base constructor initializes name and amount
        public Investment(string name, double amount)
        {
            Name = name;
            Amount = amount;
        }

        // Abstract method to be implemented by derived classes
        public abstract double CalculateReturns();

        // Method to display investment details to the console
        public virtual void DisplayInvestment()
        {
            Console.WriteLine($"Investment: {Name}, Amount: {Amount:C}");
        }
    }

    // Represents a stock investment
    class StockInvestment : Investment
    {
        private double _growthRate;

        // Constructor passes common fields to base and initializes growth rate
        public StockInvestment(string name, double amount, double growthRate)
            : base(name, amount)
        {
            _growthRate = growthRate;
        }

        // Calculates returns based on growth rate
        public override double CalculateReturns()
        {
            return Amount * _growthRate;
        }
    }

    // Represents a bond investment
    class BondInvestment : Investment
    {
        private double _interestRate;

        public BondInvestment(string name, double amount, double interestRate)
            : base(name, amount)
        {
            _interestRate = interestRate;
        }

        // Calculates returns based on interest rate
        public override double CalculateReturns()
        {
            return Amount * _interestRate;
        }
    }

    // Represents a real estate investment
    class RealEstateInvestment : Investment
    {
        private double _appreciationRate;

        public RealEstateInvestment(string name, double amount, double appreciationRate)
            : base(name, amount)
        {
            _appreciationRate = appreciationRate;
        }

        // Calculates returns based on appreciation rate
        public override double CalculateReturns()
        {
            return Amount * _appreciationRate;
        }
    }

    partial class Program
    {
        public static void ExecutePolymorphism()
        {
            Console.WriteLine("Inside Main method of polymorphism.cs");
            var logger = NLog.LogManager.GetCurrentClassLogger();

            try
            {
                // Create a list of various investments
                List<Investment> investments = new List<Investment>
                {
                    new StockInvestment("Tech Stocks", 10000, 0.12),
                    new BondInvestment("Government Bonds", 5000, 0.05),
                    new RealEstateInvestment("Commercial Property", 20000, 0.08)
                };

                // Iterate through each investment and display info
                foreach (var investment in investments)
                {
                    investment.DisplayInvestment();
                    double returns = investment.CalculateReturns();
                    Console.WriteLine($"Expected Returns: {returns:C}\n");

                    // Log investment details
                    logger.Info($"Investment: {investment.Name}, Amount: {investment.Amount}, Expected Returns: {returns}");
                }
            }
            catch (Exception ex)
            {
                // Log any runtime exceptions
                logger.Error(ex, "An error occurred while processing investments.");
                Console.WriteLine("An error occurred. Please check the logs for details.");
            }
            finally
            {
                // Flush and close loggers properly
                LogManager.Shutdown();
            }
        }
    }
}

