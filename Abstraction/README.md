# Abstraction in C#

## Overview
This C# program simulates investment banking operations, including stock buying and selling. It features two banks: **Goldman Sachs** and **JP Morgan**, each offering different investment plans.

## Features
- **Abstract Class (`IBAbstraction`)**: Defines common properties and methods for investment banks.
- **Interface (`IInvestmentServices`)**: Specifies stock trading operations.
- **Concrete Classes (`GoldmanSachs`, `JPMorgan`)**: Implement investment plans and stock trading.
- Uses **NLog** for logging transactions.
- Includes **exception handling** to catch errors gracefully.
- Includes **comments** for better understanding.

## Example Output
Bank: Goldman Sachs, Location: New York
Goldman Sachs offers high-risk, high-reward investment plans.
Goldman Sachs bought 100 shares of APPLE.
2025-06-26 09:56:00.2702 Info Bought 100 shares of APPLE.
Goldman Sachs sold 50 shares of TESLA.
2025-06-26 09:56:00.2765 Info Sold 50 shares of TESLA.

Bank: JP Morgan, Location: London
JP Morgan offers diversified investment portfolios.
JP Morgan bought 200 shares of GOOGLE.
2025-06-26 09:56:00.2765 Info Bought 200 shares of GOOGLE.
JP Morgan sold 75 shares of MICROSOFT.
2025-06-26 09:56:00.2765 Info Sold 75 shares of MICROSOFT.

## Author 
**Bhagya Sri Ramkumar**

