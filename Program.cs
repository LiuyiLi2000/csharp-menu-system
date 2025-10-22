using System;

namespace BudgetTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            BudgetManager manager = new BudgetManager();
            manager.LoadFromFile("transactions.txt");

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("💰 Personal Budget Tracker");
                Console.ResetColor();
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Income");
                Console.WriteLine("2. Add Expense");
                Console.WriteLine("3. View All Transactions");
                Console.WriteLine("4. View Balance");
                Console.WriteLine("5. Save & Exit");
                Console.WriteLine("====================================");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.AddTransaction("Income");
                        break;
                    case "2":
                        manager.AddTransaction("Expense");
                        break;
                    case "3":
                        manager.DisplayTransactions();
                        break;
                    case "4":
                        manager.DisplayBalance();
                        break;
                    case "5":
                        manager.SaveToFile("transactions.txt");
                        Console.WriteLine("✅ Data saved. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("⚠️ Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
