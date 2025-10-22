using System;
using System.Collections.Generic;
using System.IO;

namespace BudgetTracker
{
    class BudgetManager
    {
        private List<Transaction> transactions = new List<Transaction>();
        private string filePath = "transactions.txt"; // ✅ 统一文件路径

        // -----------------------------
        // 🟢 添加收入/支出
        // -----------------------------
        public void AddTransaction(string type)
        {
            Console.Write("Enter description: ");
            string desc = Console.ReadLine() ?? "";

            Console.Write("Enter amount: ");
            string input = Console.ReadLine() ?? "";

            if (decimal.TryParse(input, out decimal amount))
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

        // -----------------------------
        // 📜 查看交易记录
        // -----------------------------
        public void DisplayTransactions()
        {
            Console.WriteLine("\n📜 Transaction History:");
            Console.WriteLine("--------------------------------------------");

            if (transactions.Count == 0)
            {
                Console.WriteLine("(No transactions yet)");
            }
            else
            {
                foreach (var t in transactions)
                {
                    Console.WriteLine(t);
                }
            }

            Console.WriteLine("--------------------------------------------");
        }

        // -----------------------------
        // 💵 查看余额
        // -----------------------------
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

        // -----------------------------
        // 💾 保存到文件
        // -----------------------------
        public void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var t in transactions)
                {
                    sw.WriteLine($"{t.Type}|{t.Description}|{t.Amount}|{t.Date}");
                }
            }
        }

        // -----------------------------
        // 📂 从文件加载
        // -----------------------------
        public void LoadFromFile()
        {
            if (!File.Exists(filePath)) return;

            string[] lines = File.ReadAllLines(filePath);
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

        // -----------------------------
        // 🧹 一键清零
        // -----------------------------
        public void ResetData()
        {
            transactions.Clear(); // 清空内存数据
            File.WriteAllText(filePath, string.Empty); // 清空文件内容
            Console.WriteLine("✅ All data has been reset. Starting fresh!");
        }
    }
}
