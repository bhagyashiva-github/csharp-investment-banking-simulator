

namespace ParallelProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using NLog;

    public class TradeProcessor
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public void Run()
        {
            try
            {
                var orders = new List<(string stock, int quantity, string type)>
                {
                    ("AAPL", 100, "BUY"),
                    ("GOOGL", 50, "SELL"),
                    ("MSFT", 200, "BUY"),
                    ("TSLA", 75, "SELL")
                };

                Parallel.ForEach(orders, order =>
                {
                    try
                    {
                        PlaceOrder(order.stock, order.quantity, order.type);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, $"Error placing order for {order.stock}");
                    }
                });

                var stocks = new[] { "AAPL", "GOOGL", "MSFT", "TSLA" };

                Parallel.ForEach(stocks, stock =>
                {
                    try
                    {
                        FetchMarketData(stock);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, $"Error fetching market data for {stock}");
                    }
                });

                Parallel.Invoke(
                    () => SafeExecuteTrade("AAPL", 100, "BUY"),
                    () => SafeExecuteTrade("GOOGL", 50, "SELL"),
                    () => SafeExecuteTrade("MSFT", 200, "BUY"),
                    () => SafeExecuteTrade("TSLA", 75, "SELL")
                );

                logger.Info("Investment Banking System Completed.");
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Unhandled exception during execution.");
            }
        }

        private void SafeExecuteTrade(string stock, int qty, string type)
        {
            try
            {
                ExecuteTrade(stock, qty, type);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Error executing trade for {stock}");
            }
        }

        private void PlaceOrder(string stockSymbol, int quantity, string orderType)
        {
            logger.Info($"Placing {orderType} order for {quantity} shares of {stockSymbol}...");
            Thread.Sleep(Random.Shared.Next(1000, 3000));
            logger.Info($"Order placed successfully for {stockSymbol}.");
        }

        private void FetchMarketData(string stockSymbol)
        {
            logger.Info($"Fetching market data for {stockSymbol}...");
            Thread.Sleep(Random.Shared.Next(2000, 4000));
            var price = Random.Shared.Next(100, 200);
            logger.Info($"Market data received for {stockSymbol}: Price = ${price}");
        }

        private void ExecuteTrade(string stockSymbol, int quantity, string orderType)
        {
            logger.Info($"Executing {orderType} trade for {quantity} shares of {stockSymbol}...");
            Thread.Sleep(Random.Shared.Next(1500, 3500));
            logger.Info($"Trade executed successfully for {stockSymbol}.");
        }
    }

    partial class Program
    {
        public static void ExecuteParallelProgram()
        {
            new TradeProcessor().Run();
        }
    }
}
