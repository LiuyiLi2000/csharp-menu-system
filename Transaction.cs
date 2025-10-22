using System;

namespace BudgetTracker
{
    class Transaction
    {
        public string Type { get; set; }      // Income or Expense
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string type, string description, decimal amount)
        {
            Type = type;
            Description = description;
            Amount = amount;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd HH:mm} | {Type,-8} | {Description,-20} | ${Amount,8:F2}";
        }
    }
}
