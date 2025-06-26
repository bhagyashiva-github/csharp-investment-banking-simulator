namespace Optimization
{
    using System;
    using System.Buffers;
    using System.Buffers.Text;
    using System.Collections.Generic;
    using System.Runtime;
    using Microsoft.Extensions.ObjectPool;
    using NLog;


    // Base investment interface
    public interface IInvestment
    {
        string Type { get; }
        double Amount { get; set; }
        double CalculateReturns();
    }

    // Stock investment class
    public class Stock : IInvestment
    {
        public string Type => "Stock";
        public double Amount { get; set; }

        public double CalculateReturns() => Amount * 0.12;
    }


    // Custom policy for investment pooling
    public class InvestmentPolicy : IPooledObjectPolicy<Stock>
    {
        public Stock Create() => new Stock();
        public bool Return(Stock obj)
        {
            obj.Amount = 0;
            return true; // Ready for reuse
        }
    }

    // Simulate high-performance calculation with Span<T>
    public static class BufferProcessor
    {
        public static double ParseAmount(ReadOnlySpan<char> span)
        {
            if (double.TryParse(span, out var result))
                return result;
            throw new FormatException("Invalid amount format");
        }
    }


    partial class Program
    {
        public static void ExecuteOptimization()
        {
            Console.WriteLine("Inside Main method of optimization.cs");
            var logger = NLog.LogManager.GetCurrentClassLogger();

            logger.Info("Starting investment simulation with GC & Span optimizations");

            // Optimize GC for latency-sensitive scenarios
            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;

            var pool = new DefaultObjectPool<Stock>(new InvestmentPolicy());

            try
            {
                // Parse string inputs into Span<char> for faster processing
                string[] rawAmounts = { "10000", "5000", "8500" };

                List<IInvestment> investments = new();

                foreach (var input in rawAmounts)
                {
                    Stock stock = pool.Get();

                    // Use Span<char> to parse efficiently
                    ReadOnlySpan<char> span = input.AsSpan();
                    stock.Amount = BufferProcessor.ParseAmount(span);

                    investments.Add(stock);
                }

                // Simulate processing
                foreach (var inv in investments)
                {
                    double returns = inv.CalculateReturns();
                    logger.Info($"{inv.Type}: Invested ${inv.Amount}, Returns = ${returns}");
                }

                // Return investments to pool
                foreach (var inv in investments)
                    pool.Return((Stock)inv);
            }
            catch (Exception ex)
            {
                logger.Error($"Exception encountered: {ex.Message}");
            }
            finally
            {
                logger.Info("Simulation complete.");
                // Flush and close loggers properly
                LogManager.Shutdown();
            }


        }
    }
}
