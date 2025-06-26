# Parallel Programming in C#

## Overview
The **Parallel Investment Banking Simulator** is a C# console application that demonstrates parallel programming in an investment banking scenario. It simulates:

- Placing multiple stock orders in parallel.
- Fetching market data concurrently.
- Executing multiple trades simultaneously.

This project showcases how to use `Parallel.ForEach`, `Parallel.Invoke`, and multi-threading techniques in C# to optimize performance.

## Features
- **Parallel Order Processing**: Uses `Parallel.ForEach` to process multiple stock orders concurrently.
- **Market Data Retrieval**: Fetches stock prices in parallel.
- **Trade Execution**: Executes multiple trades simultaneously using `Parallel.Invoke`.
- **Optimized Performance**: Utilizes multi-core processing for efficiency.
- Multi-threading (`Thread.Sleep` for simulation)

## Example Output
2025-06-26 11:30:27.4305 Info Placing BUY order for 100 shares of AAPL...
2025-06-26 11:30:27.4305 Info Placing BUY order for 200 shares of MSFT...
2025-06-26 11:30:27.4305 Info Placing SELL order for 75 shares of TSLA...
2025-06-26 11:30:27.4305 Info Placing SELL order for 50 shares of GOOGL...
2025-06-26 11:30:28.8936 Info Order placed successfully for GOOGL.
2025-06-26 11:30:29.1086 Info Order placed successfully for AAPL.
2025-06-26 11:30:30.0586 Info Order placed successfully for TSLA.
2025-06-26 11:30:30.2896 Info Order placed successfully for MSFT.
2025-06-26 11:30:30.2913 Info Fetching market data for AAPL...
2025-06-26 11:30:30.2913 Info Fetching market data for TSLA...
2025-06-26 11:30:30.2913 Info Fetching market data for GOOGL...
2025-06-26 11:30:30.2913 Info Fetching market data for MSFT...
2025-06-26 11:30:32.7016 Info Market data received for GOOGL: Price = $190
2025-06-26 11:30:33.8526 Info Market data received for TSLA: Price = $108
2025-06-26 11:30:34.0476 Info Market data received for AAPL: Price = $181
2025-06-26 11:30:34.2136 Info Market data received for MSFT: Price = $183
2025-06-26 11:30:34.2153 Info Executing SELL trade for 50 shares of GOOGL...
2025-06-26 11:30:34.2153 Info Executing BUY trade for 200 shares of MSFT...
2025-06-26 11:30:34.2153 Info Executing BUY trade for 100 shares of AAPL...
2025-06-26 11:30:34.2153 Info Executing SELL trade for 75 shares of TSLA...
2025-06-26 11:30:36.2125 Info Trade executed successfully for MSFT.
2025-06-26 11:30:36.4722 Info Trade executed successfully for TSLA.
2025-06-26 11:30:36.5115 Info Trade executed successfully for GOOGL.
2025-06-26 11:30:36.9615 Info Trade executed successfully for AAPL.

## Author 
**Bhagya Sri Ramkumar**