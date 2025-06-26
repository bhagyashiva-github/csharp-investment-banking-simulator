namespace DataStructures
{
    using System;
    using System.Collections.Generic;
    using NLog;

    /// <summary>
    /// Represents a single market data tick in high-frequency trading.
    /// Value-type struct is optimal for performance (avoids heap allocation).
    /// </summary>
    public readonly struct InvestmentTick
    {
        public string Symbol { get; }
        public double Price { get; }
        public long Volume { get; }
        public DateTime Timestamp { get; }

        public InvestmentTick(string symbol, double price, long volume, DateTime timestamp)
        {
            Symbol = symbol;
            Price = price;
            Volume = volume;
            Timestamp = timestamp;
        }

        // Displays the tick details to the console
        public void Print()
        {
            Console.WriteLine($"[Tick] {Timestamp:HH:mm:ss} | {Symbol} | Price: {Price:C} | Volume: {Volume:N0}");
        }
    }
    partial class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static void ExecuteStructs()
        {
            Console.WriteLine("Inside Main method of structs.cs");
            logger.Info("📈 High-Frequency Trading Tick Simulation Started");

            try
            {
                // Create a list of sample market ticks
                List<InvestmentTick> ticks = new()
            {
                new InvestmentTick("AAPL", 182.40, 1000, DateTime.Now),
                new InvestmentTick("TSLA", 756.22, 1500, DateTime.Now.AddMilliseconds(1)),
                new InvestmentTick("GOOG", 2650.10, 500, DateTime.Now.AddMilliseconds(2))
            };

                // Process and log each tick
                foreach (var tick in ticks)
                {
                    try
                    {
                        logger.Info($"Processing tick for {tick.Symbol}");
                        tick.Print();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, "Error printing tick");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Unexpected error occurred");
            }

            logger.Info("Tick simulation complete");
        }
    }
}
