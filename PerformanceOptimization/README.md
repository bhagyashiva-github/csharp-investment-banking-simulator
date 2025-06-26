# 🔄 Investment Optimizer with GC Tuning, Span<T>, and NLog in C#

## Overview
This project showcases a high-performance investment simulation that uses:

- `Span<T>` for efficient parsing and fast, memory-safe buffer handling
- Object pooling via `DefaultObjectPool<T>`
- Garbage Collection Optimization with GCSettings.LatencyMode
- Structured logging with **NLog**

## Features
- Parses investment input using `ReadOnlySpan<char>`
- Calculates stock returns efficiently
- Uses custom `IPooledObjectPolicy<Stock>` to minimize allocations
- Optimized for `SustainedLowLatency` GC scenarios

## Example Output 
[LOG] Starting investment simulation with GC & Span optimizations
Stock: Invested $10000, Returns = $1200
Simulation complete.

## Author 
**Bhagya Sri Ramkumar**
