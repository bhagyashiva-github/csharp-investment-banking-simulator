
namespace AsynchronousTrading
{
    using System;
    using System.Threading.Tasks;
    using NLog;

    public class TradeProcessor
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public async Task RunAsync()
        {
            try
            {
                var orderTask = PlaceOrderAsync("APPLE", 100, "BUY");
                var marketDataTask = FetchMarketDataAsync("APPLE");

                await Task.WhenAll(orderTask, marketDataTask);

                await ExecuteTradeAsync("APPLE", 100, "BUY");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during the trade process.");
            }
        }

        private async Task PlaceOrderAsync(string stockSymbol, int quantity, string orderType)
        {
            logger.Info($"Placing {orderType} order for {quantity} shares of {stockSymbol}");
            await Task.Delay(2000); // Simulating network delay
            logger.Info($"Order placed successfully for {stockSymbol}");
        }

        private async Task FetchMarketDataAsync(string stockSymbol)
        {
            logger.Info($"Fetching market data for {stockSymbol}");
            await Task.Delay(3000); // Simulating API call delay
            var price = new Random().Next(100, 200);
            logger.Info($"Market data received for {stockSymbol}: Price = ${price}");
        }

        private async Task ExecuteTradeAsync(string stockSymbol, int quantity, string orderType)
        {
            logger.Info($"Executing {orderType} trade for {quantity} shares of {stockSymbol}");
            await Task.Delay(2500); // Simulating trade execution delay
            logger.Info($"Trade executed successfully for {stockSymbol}");
        }
    }

    partial class Program
    {
        public static async Task ExceuteAsynchronousAsync()
        {
            var processor = new TradeProcessor();
            await processor.RunAsync();
        }
    }
}
