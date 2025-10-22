using System;
using System.Collections.Generic;
using System.IO;

namespace BudgetTracker
{
    class BudgetManager
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(string type)
        {
            Console.Write("Enter description: ");
            string desc = Console.ReadLine();

            Console.Write("Enter amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                if (type == "Expense") amount = -Math.Abs(amount);
                transactions.Add(new Transaction(type, desc, amount));
                Console.WriteLine("✅ Transaction added successfully!");
            }
            else
            {
                Console.WriteLine("⚠️ Invalid amount. Try again.");
            }
        }

        public void DisplayTransactions()
        {
            Console.WriteLine("\n📜 Transaction History:");
            Console.WriteLine("--------------------------------------------");
            foreach (var t in transactions)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("--------------------------------------------");
        }

        public void DisplayBalance()
        {
            decimal balance = 0;
            foreach (var t in transactions) balance += t.Amount;

            Console.WriteLine($"\n💵 Current Balance: ${balance:F2}");
            if (balance < 0)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (balance > 1000)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Yellow;

            Console.ResetColor();
        }

        public void SaveToFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (var t in transactions)
                {
                    sw.WriteLine($"{t.Type}|{t.Description}|{t.Amount}|{t.Date}");
                }
            }
        }

        public void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName)) return;

            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 4 && decimal.TryParse(parts[2], out decimal amt))
                {
                    Transaction t = new Transaction(parts[0], parts[1], amt)
                    {
                        Date = DateTime.Parse(parts[3])
                    };
                    transactions.Add(t);
                }
            }
        }
    }
}
