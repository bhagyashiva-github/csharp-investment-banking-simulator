namespace EventDrivenProgramming
{
    using System;
    using System.Collections.Generic;
    using NLog;

    // Event Delegate Declaration
    public delegate void InvestmentChangedEventHandler(object sender, InvestmentChangedEventArgs e);

    // Custom EventArgs to describe investment changes
    public class InvestmentChangedEventArgs : EventArgs
    {
        public string InvestmentType { get; }
        public double OldValue { get; }
        public double NewValue { get; }

        public InvestmentChangedEventArgs(string investment, double oldVal, double newVal)
        {
            InvestmentType = investment;
            OldValue = oldVal;
            NewValue = newVal;
        }
    }

    // Market acts as publisher, raising events on value changes
    public class Market
    {
        public event InvestmentChangedEventHandler? OnInvestmentChanged;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();


        public void UpdateInvestmentValue(string investment, double oldVal, double newVal)
        {
            try
            {
                logger.Info($"Market is updating {investment} value from {oldVal} to {newVal}");
                OnInvestmentChanged?.Invoke(this, new InvestmentChangedEventArgs(investment, oldVal, newVal));
            }
            catch (Exception ex)
            {
                logger.Error($"Exception during event raise: {ex.Message}");
            }
        }
    }

    // Investor subscribes to investment changes
    public class Investor
    {
        public string Name { get; }

        public Investor(string name) => Name = name;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Notify(object sender, InvestmentChangedEventArgs e)
        {
            try
            {
                logger.Info($"{Name} received update for {e.InvestmentType}");
                string reaction = e.NewValue > e.OldValue ? "gained" : "lost";
                Console.WriteLine($"[INVESTOR ALERT]: {Name} has {reaction} value on {e.InvestmentType}: from {e.OldValue:C} to {e.NewValue:C}");
            }
            catch (Exception ex)
            {
                logger.Error($"Error in investor notify: {ex.Message}");
            }
        }
    }

    // Main Entry 
    partial class Program
    {
        public static void ExecuteEventDrivenProgramming()
        {
            //Logger.Instance.Log("Simulation started");
            Console.WriteLine("Inside Main method of eventdriven.cs");
            var logger = NLog.LogManager.GetCurrentClassLogger();

            try
            {
                var market = new Market();

                // Register investors
                var john = new Investor("John");
                var elena = new Investor("Elena");

                market.OnInvestmentChanged += john.Notify;
                market.OnInvestmentChanged += elena.Notify;

                // Trigger investment changes
                market.UpdateInvestmentValue("Tech ETF", 10000, 10700);
                market.UpdateInvestmentValue("Real Estate Trust", 5000, 4800);

                logger.Info("Simulation ended");
            }
            catch (Exception ex)
            {
                logger.Error($"Unexpected error: {ex.Message}");
            }
            finally
            {
                // Flush and close loggers properly
                LogManager.Shutdown();
            }
        }
    }
}
