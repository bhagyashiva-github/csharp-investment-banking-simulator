# Parallel Investment Banking Simulation (C# TPL)

## Overview
A high-performance investment simulation built in C# using the **Task Parallel Library (TPL)**.

## Features

- Parallel processing with `Parallel.ForEach` and  `Parallel.For`
- Investment types: Stock, Bond, Crypto
- Expected returns calculated in parallel threads
- Uses **NLog** for logging transactions.
- Includes **exception handling** to catch errors gracefully.

## 🔍 Sample Output
Stocks: Invested $10000, Expected Returns: $1200
Crypto: Invested $7000, Expected Returns: $1400
Bonds: Invested $2000, Expected Returns: $100
Stocks: Invested $15000, Expected Returns: $1800
Bonds: Invested $5000, Expected Returns: $250
Account 4: Updated Balance = $34,240.00
Account 2: Updated Balance = $26,750.00
Account 3: Updated Balance = $5,350.00
Account 1: Updated Balance = $10,700.00
Account 5: Updated Balance = $19,260.00

## Author 
**Bhagya Sri Ramkumar**