namespace Abstraction
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using NLog;


    // Abstract class representing an Investment Bank
    internal abstract class IBAbstraction
    {
        public string BankName { get; set; }
        public string Location { get; set; }

        // Constructor to initialize bank details
        public IBAbstraction(string name, string location)
        {
            this.BankName = name;
            this.Location = location;
        }

        // Abstract method to be implemented by derived classes
        public abstract void OfferInvestmentPlan();

        // Common method to display bank information
        public void DisplayBankInfo()
        {
            Console.WriteLine($"Bank: {this.BankName}, Location: {this.Location}");
        }
    }
    internal interface IInvestmentServices
    {
        void BuyStocks(string stock, int quantity);
        void SellStocks(string stock, int quantity);
    }

    // Concrete class representing Goldman Sachs
    internal class GoldmanSachs : IBAbstraction, IInvestmentServices
    {

        public GoldmanSachs(string location) : base("Goldman Sachs", location) { }

        public override void OfferInvestmentPlan()
        {
            Console.WriteLine($"{this.BankName} offers high-risk, high-reward investment plans.");
        }

        public void BuyStocks(string stock, int quantity)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();

            try
            {
                if (quantity <= 0)
                    throw new ArgumentException("Quantity must be greater than zero.");

                Console.WriteLine($"{this.BankName} bought {quantity} shares of {stock}.");
                logger.Info($"Bought {quantity} shares of {stock}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                logger.Error(ex);
            }
        }

        public void SellStocks(string stock, int quantity)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            try
            {
                if (quantity <= 0)
                    throw new ArgumentException("Quantity must be greater than zero.");

                Console.WriteLine($"{this.BankName} sold {quantity} shares of {stock}.");
                logger.Info($"Sold {quantity} shares of {stock}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                logger.Error(ex);
            }
        }
    }

    // Concrete class representing JP Morgan
    internal class JPMorgan : IBAbstraction, IInvestmentServices
    {
        public JPMorgan(string location) : base("JP Morgan", location) { }


        public override void OfferInvestmentPlan()
        {
            Console.WriteLine($"{this.BankName} offers diversified investment portfolios.");
        }

        public void BuyStocks(string stock, int quantity)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            try
            {
                if (quantity <= 0)
                    throw new ArgumentException("Quantity must be greater than zero.");

                Console.WriteLine($"{this.BankName} bought {quantity} shares of {stock}.");
                logger.Info($"Bought {quantity} shares of {stock}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                logger.Error(ex);
            }
        }

        public void SellStocks(string stock, int quantity)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            try
            {
                if (quantity <= 0)
                    throw new ArgumentException("Quantity must be greater than zero.");

                Console.WriteLine($"{this.BankName} sold {quantity} shares of {stock}.");
                logger.Info($"Sold {quantity} shares of {stock}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                logger.Error(ex);
            }
        }
    }

    partial class Program
    {
        public static void ExecuteAbstraction()
        {
            Console.WriteLine("Inside Main method of abstraction.cs");
            var logger = NLog.LogManager.GetCurrentClassLogger();

            try
            {
                IBAbstraction gs = new GoldmanSachs("New York");
                gs.DisplayBankInfo();
                gs.OfferInvestmentPlan();

                IInvestmentServices gsServices = new GoldmanSachs("New York");
                gsServices.BuyStocks("APPLE", 100);
                gsServices.SellStocks("TESLA", 50);

                Console.WriteLine();

                IBAbstraction jp = new JPMorgan("London");
                jp.DisplayBankInfo();
                jp.OfferInvestmentPlan();

                IInvestmentServices jpServices = new JPMorgan("London");
                jpServices.BuyStocks("GOOGLE", 200);
                jpServices.SellStocks("MICROSOFT", 75);
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


