namespace PaymentReport
{
    public class PaymentReportLibrary
    {
        public class User
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public List<Expense> Expenses { get; set; }
            public decimal TotalIncome { get; set; }
            public string V1 { get; }
            public string V2 { get; }
            public string V3 { get; }

            public User (string name, string email, string password, List<Expense> expense, decimal TotalIncome)
            {
                Name = name;
                Email = email;
                Password = password;
                Expenses = expense;
                this.TotalIncome = TotalIncome;
            }

            public User(string v1, string v2, string v3)
            {
                V1 = v1;
                V2 = v2;
                V3 = v3;
            }
        }
        public class Expense
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
        }

        public class PaymentRepost
        {
            public decimal CalculateTotalIncome(User user)
            {
                decimal totalIncome = user.TotalIncome;
                return totalIncome;
            }

            public decimal CalculateTotalExpenses(User user, int month, int year)
            {
                decimal totalExpense = 0;

                foreach (Expense expense in user.Expenses)
                {
                    if (expense.Date.Month == month && expense.Date.Year == year)
                    {
                        totalExpense += expense.Amount;
                    }
                }

                return totalExpense;
            }

            public decimal CalculateNetIncome(User user, int month, int year)
            {
                decimal totalIncome = CalculateTotalIncome(user);
                decimal totalExpense = CalculateTotalExpenses(user, month, year);

                decimal netIncome = totalIncome - totalExpense;
                return netIncome;
            }
        }
    }
}