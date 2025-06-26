# Asynchronous Programming in C#

## Overview
This project demonstrates asynchronous programming in an investment banking scenario. It simulates:

- Placing stock orders asynchronously.
- Fetching market data asynchronously.
- Executing trades asynchronously.

It shows how to use `async` and `await` in C# to handle multiple tasks efficiently.

## Features
- **Asynchronous Order Processing**: Simulates placing buy/sell orders.
- **Market Data Retrieval**: Fetches stock prices asynchronously.
- **Trade Execution**: Executes trades after order and market data are ready.
- **Concurrent Task Handling**: Uses `Task.WhenAll` to optimize performance.

- Uses **NLog** for logging transactions.
- Includes **exception handling** to catch errors gracefully.
- Includes **comments** for better understanding.

## Technologies Used
- C# (.NET 9)
- Asynchronous Programming (`async` / `await`)
- Task-based Parallelism (`Task.Delay` for simulation)

## Example Output
2025-06-26 10:47:41.6080|Info|AsynchronousTrading.TradeProcessor|Placing BUY order for 100 shares of APPLE 
2025-06-26 10:47:41.6150|Info|AsynchronousTrading.TradeProcessor|Fetching market data for APPLE 
2025-06-26 10:47:43.6187|Info|AsynchronousTrading.TradeProcessor|Order placed successfully for APPLE 
2025-06-26 10:47:44.6168|Info|AsynchronousTrading.TradeProcessor|Market data received for APPLE: Price = $100 
2025-06-26 10:47:44.6184|Info|AsynchronousTrading.TradeProcessor|Executing BUY trade for 100 shares of APPLE 
2025-06-26 10:47:47.1199|Info|AsynchronousTrading.TradeProcessor|Trade executed successfully for APPLE 

## Author
**BHAGYA SRI RAMKUMAR**
