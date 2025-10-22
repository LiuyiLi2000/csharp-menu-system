using System;

namespace BudgetTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            BudgetManager manager = new BudgetManager();
            manager.LoadFromFile(); // ✅ 不再需要传参数

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
                Console.WriteLine("6. Reset All Data");
                Console.WriteLine("====================================");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine() ?? ""; // ✅ 防止 null

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
                        manager.SaveToFile(); // ✅ 不再需要传参数
                        Console.WriteLine("✅ Data saved. Goodbye!");
                        return;
                    case "6":
                        manager.ResetData(); // ✅ 一键清零功能
                        Console.WriteLine("✅ All data cleared successfully!");
                        break;
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
