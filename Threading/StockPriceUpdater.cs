using System;
using System.Threading;

public static class StockPriceUpdater
{
    public static void StartStockUpdates()
    {
        Thread stockThread = new Thread(UpdateStockPrices);
        stockThread.Start();
    }

    private static void UpdateStockPrices()
    {
        string[] stocks = { "AAPL", "GOOGL", "MSFT", "TSLA", "AMZN" };
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            foreach (var stock in stocks)
            {
                double price = random.Next(100, 500) + random.NextDouble();
                Console.WriteLine($"[Thread] {stock} Price Updated: ${price:F2}");
            }
            Thread.Sleep(2000); // Simulate delay
        }
    }
}
