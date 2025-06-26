# Design Patterns in C#

## Overview
This project simulates core investment banking operations using C# and design patterns.

## Patterns Used
- **Factory**: Dynamically create investments.
- **Observer**: Notify clients of market updates.
- **Singleton**: Central logger instance.
- **Repository**: Manage investment data.

## Project Structure 
IInvestment, Stock, Bond → Factory Pattern
MarketNotification, InvestmentClient → Observer Pattern
Logger → Singleton Pattern
InvestmentRepository → Repository Pattern
Program.cs → Main application entry
README.md → Usage guide

## Example Output
[LOG]: 6/25/2025 8:09:49 PM: Processed Stock ($10000): Expected Return = $1200
[Notification to John]: Stock updated! Returns: $1200
[LOG]: 6/25/2025 8:09:49 PM: Processed Bond ($5000): Expected Return = $250
[Notification to John]: Bond updated! Returns: $250

## Author 
**Bhagya Sri Ramkumar**