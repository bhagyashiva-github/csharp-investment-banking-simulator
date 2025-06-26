# ⚡ HFT Simulation with Structs in C#

Simulates a high-performance market tick stream using `struct`, ideal for high-frequency trading (HFT) scenarios.

## Why to Use Struct?
- **Faster access**: Stored on the stack.
- **Reduced GC pressure**: Ideal for millions of short-lived tick events.
- **Better performance** for data that doesn't require reference semantics.

## Features
- Defines `InvestmentTick` struct for tick data.
- Creates and prints a list of simulated trading ticks.
- Uses **NLog** for logging transactions.
- Includes **exception handling** to catch errors gracefully.
- Includes **comments** for better understanding.

## Sample Output
[Tick] 20:31:59 | AAPL | Price: $182.40 | Volume: 1,000
[Tick] 20:31:59 | TSLA | Price: $756.22 | Volume: 1,500
[Tick] 20:31:59 | GOOG | Price: $2,650.10 | Volume: 500

## Author 
**Bhagya Sri Ramkumar**
