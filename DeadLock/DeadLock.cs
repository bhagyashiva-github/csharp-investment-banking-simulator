using System;
using System.Threading;

namespace DeadLock
{
    // Bank Account class representing an investment account
    class BankAccount
    {
        public int AccountId { get; }
        public decimal Balance { get; private set; }

        // Constructor to initialize account details
        public BankAccount(int id, decimal initialBalance)
        {
            AccountId = id;
            Balance = initialBalance;
        }

        // Withdraw money from the account
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        // Deposit money into the account
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }

    // Bank class handling transactions
    class Bank
    {
        // Simulating a deadlock scenario
        public void TransferWithDeadlock(BankAccount from, BankAccount to, decimal amount)
        {
            lock (from) // Lock first account
            {
                Thread.Sleep(100); // Simulating delay
                lock (to) // Lock second account
                {
                    if (from.Balance >= amount)
                    {
                        from.Withdraw(amount);
                        to.Deposit(amount);
                        Console.WriteLine($"Transferred {amount} from Account {from.AccountId} to {to.AccountId}");
                    }
                }
            }
        }

        // Solution 1: Preventing deadlock using consistent lock ordering
        public void TransferWithLockOrdering(BankAccount from, BankAccount to, decimal amount)
        {
            // Always lock accounts in ascending order of AccountId
            BankAccount firstLock = from.AccountId < to.AccountId ? from : to;
            BankAccount secondLock = from.AccountId < to.AccountId ? to : from;

            lock (firstLock)
            {
                Thread.Sleep(100); // Simulating delay
                lock (secondLock)
                {
                    if (from.Balance >= amount)
                    {
                        from.Withdraw(amount);
                        to.Deposit(amount);
                        Console.WriteLine($"[Lock Ordering] Transferred {amount} from Account {from.AccountId} to {to.AccountId}");
                    }
                }
            }
        }

        // Solution 2: Preventing deadlock using TryLock with timeout
        public void TransferWithTryLock(BankAccount from, BankAccount to, decimal amount)
        {
            //If locks can't be acquired within 1 second, the transaction fails gracefully
            bool lockA = Monitor.TryEnter(from, TimeSpan.FromSeconds(1));
            bool lockB = Monitor.TryEnter(to, TimeSpan.FromSeconds(1));

            if (lockA && lockB)
            {
                try
                {
                    if (from.Balance >= amount)
                    {
                        from.Withdraw(amount);
                        to.Deposit(amount);
                        Console.WriteLine($"[TryLock] Transferred {amount} from Account {from.AccountId} to {to.AccountId}");
                    }
                }
                finally
                {
                    Monitor.Exit(from);
                    Monitor.Exit(to);
                }
            }
            else
            {
                Console.WriteLine("[TryLock] Transaction failed due to locking issues.");
            }
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {

            BankAccount accountA = new BankAccount(1, 5000);
            BankAccount accountB = new BankAccount(2, 7000);
            Bank bank = new Bank();

            // Simulating deadlock scenario

            Thread thread1 = new Thread(() => bank.TransferWithDeadlock(accountA, accountB, 1000));
            Thread thread2 = new Thread(() => bank.TransferWithDeadlock(accountB, accountA, 2000));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("\nDeadlock occurred\n");

            // Solution 1: Using Lock Ordering
            Console.WriteLine("\nPreventing Deadlock by using Lock Order\n");

            Thread thread3 = new Thread(() => bank.TransferWithLockOrdering(accountA, accountB, 1000));
            Thread thread4 = new Thread(() => bank.TransferWithLockOrdering(accountB, accountA, 2000));

            thread3.Start();
            thread4.Start();

            thread3.Join();
            thread4.Join();


            // Solution 2: Using TryLock with Timeout
            Console.WriteLine("\nPreventing Deadlock by using TryLock with Timeout\n");

            Thread thread5 = new Thread(() => bank.TransferWithTryLock(accountA, accountB, 1000));
            Thread thread6 = new Thread(() => bank.TransferWithTryLock(accountB, accountA, 2000));

            thread5.Start();
            thread6.Start();

            thread5.Join();
            thread6.Join();

        }
    }
}

