using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Investment Bank System Started...\n");

        // Start stock price updates in a separate thread
        StockPriceUpdater.StartStockUpdates();

        // Process transactions asynchronously
        await TransactionProcessor.ProcessTransactionsAsync();

        // Generate reports using parallel processing
        ReportGenerator.GenerateReportsParallel();

        Console.WriteLine("\nInvestment Bank System Completed.");
    }
}
