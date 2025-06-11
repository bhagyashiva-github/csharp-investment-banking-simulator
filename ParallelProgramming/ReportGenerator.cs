using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public static class ReportGenerator
{
    public static void GenerateReportsParallel()
    {
        List<string> reports = new List<string> { "Quarterly Report", "Annual Report", "Risk Analysis", "Market Trends", "Investment Portfolio" };

        Console.WriteLine("\nGenerating Reports in Parallel...");
        Parallel.ForEach(reports, report =>
        {
            Thread.Sleep(1500); // Simulate report generation delay
            Console.WriteLine($"[Parallel] Report Generated: {report}");
        });
    }
}
