# Event-Driven in C#

## Overview
This project demonstrates a simplified investment banking simulation using **event-driven programming** in C#. It models how investors react to market fluctuations using `delegates`, `events`, and `event handlers`.

## Features

- Delegates and Events
- Custom EventArgs for context-rich updates
- Exception-safe event publishing and subscribing
- Uses **NLog** for logging transactions.
- Includes **exception handling** to catch errors gracefully.

## How It Works

1. `Market` raises events on value updates.
2. `Investor` instances subscribe to the market.
3. When the event triggers, all subscribers receive the update via event handlers.
4. All steps are logged and guarded against exceptions.

## Example output

[INVESTOR ALERT]: John has gained value on Tech ETF: from $10,000.00 to $10,700.00
[INVESTOR ALERT]: Elena has gained value on Tech ETF: from $10,000.00 to $10,700.00
[INVESTOR ALERT]: John has lost value on Real Estate Trust: from $5,000.00 to $4,800.00
[INVESTOR ALERT]: Elena has lost value on Real Estate Trust: from $5,000.00 to $4,800.00

## Author 
**Bhagya Sri Ramkumar**
