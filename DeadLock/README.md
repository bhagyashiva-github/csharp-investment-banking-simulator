# Deadlock Prevention in C#

## Overview
This project demonstrates **deadlock scenarios** in multi-threaded bank transactions and provides **two solutions** to prevent deadlocks using:

1. **Lock Ordering** (Consistent locking order)
2. **TryLock with Timeout** (Graceful failure if locks can't be acquired)

## Problem Statement
When multiple threads attempt to transfer money between two bank accounts, they may **lock resources in different orders**, leading to a **deadlock** where neither thread can proceed.

### Example Deadlock Scenario:
- **Thread 1** locks `Account A` and waits for `Account B`.
- **Thread 2** locks `Account B` and waits for `Account A`.
- Both threads are stuck indefinitely.

## Solutions Implemented

### 1️⃣ Lock Ordering
- Always acquire locks in a **consistent order** based on `AccountId`.
- Prevents circular waiting, ensuring smooth execution.

### 2️⃣ TryLock with Timeout
- Uses `Monitor.TryEnter()` to attempt acquiring locks with a **timeout**.
- If locks can't be acquired within **1 second**, the transaction fails gracefully, avoiding deadlock.

## Code Structure
- `BankAccount.cs` → Represents a bank account with `Withdraw()` and `Deposit()` methods.
- `Bank.cs` → Handles transactions and implements deadlock prevention techniques.
- `Program.cs` → Simulates transactions using multiple threads.

## Example Output
Preventing Deadlock by using Lock Order

[Lock Ordering] Transferred 1000 from Account 1 to 2
[Lock Ordering] Transferred 2000 from Account 2 to 1

Preventing Deadlock by using TryLock with Timeout

[TryLock] Transferred 1000 from Account 1 to 2
[TryLock] Transferred 2000 from Account 2 to 1

## Author
**BHAGYA SRI RAMKUMAR**
