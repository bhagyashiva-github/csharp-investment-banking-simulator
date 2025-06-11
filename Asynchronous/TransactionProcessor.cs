using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class TransactionProcessor
{
    public static async Task ProcessTransactionsAsync()
    {
        List<string> transactions = new List<string> { "Buy AAPL", "Sell TSLA", "Buy MSFT", "Sell AMZN", "Buy GOOGL" };

        foreach (var transaction in transactions)
        {
            await Task.Delay(1000); // Simulate transaction processing delay
            Console.WriteLine($"[Async] Transaction Processed: {transaction}");
        }
    }
}
