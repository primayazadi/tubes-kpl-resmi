using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using PaymentReport;
using ValidationLibrary;

using static PaymentReminder;
using static PaymentReport.PaymentReportLibrary;

namespace tubesbackuup
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Expense> Expenses { get; set; }
        public decimal TotalIncome { get; set; }
    }

    public class Expense
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

    class Program
    {
        static List<User> users = new List<User>();

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.WriteLine();

                int choice = GetIntFromUser("Enter your choice: ");
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        User user = LoginUser();
                        if (user != null)
                        {
                            Console.WriteLine($"Welcome, {user.Name}!");
                            Console.WriteLine();
                            Dashboard(user);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Invalid email or password.");
                        }
                        break;
                    case 2:
                        RegisterUser();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void RegisterUser()
        {
            Console.WriteLine("Please enter your details:");
            Console.WriteLine();

            string name = GetStringFromUser("Name: ");
            string email = GetStringFromUser("Email: ");
            string password = GetStringFromUser("Password: ");

            User user = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Expenses = new List<Expense>()
            };

            users.Add(user);

            Console.WriteLine("Registration successful.");
        }

        static User LoginUser()
        {
            string email = GetStringFromUser("Email: ");
            string password = GetStringFromUser("Password: ");

            User user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

            return user;
        }

        static void Dashboard(User user)
        {
            RuntimeConfig config = new RuntimeConfig();
            while (true)
            {
                Console.WriteLine("1. Add income");
                Console.WriteLine("2. Add expense");
                Console.WriteLine("3. View financial report");
                Console.WriteLine("4. Logout");
                Console.WriteLine("5. View configuration");
                Console.WriteLine("6. Data Tambahan User. ");
                Console.WriteLine("7. Kategori pengeluaran.");
                Console.WriteLine("8. Payment Reminder. ");
                Console.WriteLine("9. update information");
                Console.WriteLine("10. TesAddIncome");
                Console.WriteLine("11. kategori pemasukan");


                Console.WriteLine();

                int choice = GetIntFromUser("Enter your choice: ");
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddIncome(user);

                        break;
                    case 2:
                        AddExpense(user);
                        break;
                    case 3:
                        ViewFinancialReport(user);
                        break;
                    case 4:
                        Console.WriteLine("You have successfully logged out.");
                        return;
                    case 5:
                        //runtime config
                        Console.WriteLine("Current configuration:");
                        Console.WriteLine($"Sumber pendapatan: {config.config.sumberPendapatan}");
                        Console.WriteLine($"Sumber pengeluaran: {config.config.sumberPengeluaran}");
                        Console.WriteLine($"Jangka analisis: {config.config.jangkaAnalisis}");
                        Console.WriteLine();

                        Console.WriteLine("Do you want to change the configuration? (Y/N)");
                        string response = Console.ReadLine();
                        if (response.ToLower() == "y")
                        {
                            changeConfiguration(config);
                        }

                        break;
                    case 6:
                        //geenric
                        Console.Write("Masukkan hobi Anda: ");
                        string hobi = Console.ReadLine();

                        Console.Write("Masukkan passive income Anda: ");
                        string passiveIncome = Console.ReadLine();

                        Console.Write("Masukkan jumlah anak Anda: ");
                        string jumlahAnak = Console.ReadLine();

                        Console.Write("Masukkan pendidikan terakhir Anda: ");
                        string pendidikanTerakhir = Console.ReadLine();

                        InformasiTambahan<string> informasi = new InformasiTambahan<string>(hobi, passiveIncome, jumlahAnak, pendidikanTerakhir);

                        Console.WriteLine("Hobi: " + informasi.hobi);
                        Console.WriteLine("Passive Income: " + informasi.passiveIncome);
                        Console.WriteLine("Jumlah Anak: " + informasi.jumlahAnak);
                        Console.WriteLine("Pendidikan Terakhir: " + informasi.pendidikanTerakhir);

                        Console.ReadLine();

                        break;
                    case 7:
                        //tebldrivn
                        MoneyManager moneyManager = new MoneyManager();

                        Console.Write("Masukkan deskripsi pengeluaran:");
                        string deskripsi = Console.ReadLine();

                        Console.Write("Masukkan jumlah uang:");
                        double jumlahUang = double.Parse(Console.ReadLine());

                        Pengeluaran pengeluaran = new Pengeluaran()
                        {
                            Deskripsi = deskripsi,
                            JumlahUang = jumlahUang
                        };

                        moneyManager.CetakKategoriPengeluaran(pengeluaran);

                        Console.ReadLine();
                        break;
                    
                    case 8:
                        PaymentReminder[] reminders = {
                        new PaymentReminder("Pembayaran WiFi", "Rp 200.000"),
                        new PaymentReminder("Pembayaran Listrik", "Rp 500.000"),
                        new PaymentReminder("Gaji Karyawan", "Rp 10.000.000")
                         };

                        Console.WriteLine("Payment Reminders:");
                        Console.WriteLine("-------------------");

                        foreach (PaymentReminder reminder in reminders)
                        {
                            Console.WriteLine($"- {reminder.Name}: {reminder.Amount}");
                        }
                
                         break;

                    case 9:
                        RuntimeConfigu runtimeConfig = new RuntimeConfigu();
                        // Mengubah konfigurasi
                        runtimeConfig.changeConfiguration();
                        
                        break;

                    case 10:
                        var tUser = new User();
                        decimal amount = GetDecimalFromUser("Amount: ");
                        TesAddIncome(user, amount);
                        Console.WriteLine($"Total Income: ${user.TotalIncome}");

                        static void TesAddIncome(User user, decimal amount)
                        {
                            user.TotalIncome += amount;
                            Console.WriteLine($"${amount} has been added to your income.");
                        }

                        static decimal GetDecimalFromUser(string message)
                        {
                            Console.Write(message);
                            while (true)
                            {
                                string input = Console.ReadLine();
                                try
                                {
                                    decimal result = Convert.ToDecimal(input);
                                    return result;
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid number.");
                                    Console.Write(message);
                                }
                            }
                        }
                        break;
                        
                    case 11:
                        var moneyManagerr = new MoneyManagerr();

                        var pemasukan1 = new Pemasukan()
                        {
                            Deskripsi = "WIfi",
                            JumlahUang = 250000
                        };
                        moneyManagerr.CetakKategoriPemasukan(pemasukan1);

                        var pemasukan2 = new Pemasukan()
                        {
                            Deskripsi = "listrik",
                            JumlahUang = 600000
                        };
                        moneyManagerr.CetakKategoriPemasukan(pemasukan2);

                        var pemasukan3 = new Pemasukan()
                        {
                            Deskripsi = "gaji karyawan",
                            JumlahUang = 3000000
                        };
                        moneyManagerr.CetakKategoriPemasukan(pemasukan3);
                        break;


                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                    
                }

                Console.WriteLine();
            }
        }

        static void ViewFinancialReport(User user)
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            List<PaymentReportLibrary.Expense> _expense = new List<PaymentReportLibrary.Expense>();
            _expense = user.Expenses.Select(e => new PaymentReport.PaymentReportLibrary.Expense
            {
                Amount = e.Amount,
                Date = e.Date,
                UserId = e.UserId,
                Name = e.Name
            }).ToList();
            PaymentReport.PaymentReportLibrary.User _user = new PaymentReport.PaymentReportLibrary.User(user.Name, user.Email, user.Password, _expense, user.TotalIncome);
            PaymentRepost report = new PaymentRepost();
            decimal totalIncome = report.CalculateTotalIncome(_user);
            decimal totalExpense = report.CalculateTotalExpenses(_user, currentMonth, currentYear);
            decimal netIncome = report.CalculateNetIncome(_user, currentMonth, currentYear);

            Console.WriteLine($"Financial report for {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(currentMonth)} {currentYear}");
            Console.WriteLine();
            Console.WriteLine($"Total income: {totalIncome:C}");
            Console.WriteLine($"Total expenses: {totalExpense:C}");
            Console.WriteLine($"Net income: {netIncome:C}");
            Console.WriteLine();
        }

        static void AddIncome(User user)
        {
            decimal amount = GetDecimalFromUser("Amount: ");
            user.TotalIncome += amount;
            Console.WriteLine($"${amount} has been added to your income.");
        }

        static void AddExpense(User user)
        {
            string name = GetStringFromUser("Name: ");
            decimal amount = GetDecimalFromUser("Amount: ");
            DateTime date = GetDateFromUser("Date (MM/dd/yyyy): ");

            Expense expense = new Expense
            {
                Name = name,
                Amount = amount,
                Date = date
            };

            user.Expenses.Add(expense);

            Console.WriteLine($"${amount} has been added to your expenses.");
        }

        static string GetStringFromUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        static int GetIntFromUser(string message)
        {
            Console.Write(message);
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                Console.Write(message);
            }
            return value;
        }

        static decimal GetDecimalFromUser(string message)
        {
            Console.Write(message);
            decimal value;
            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                Console.Write(message);
            }
            return value;
        }

        static DateTime GetDateFromUser(string message)
        {
            Console.Write(message);
            DateTime value;
            while (!DateTime.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid input. Please enter a valid date (MM/dd/yyyy).");
                Console.Write(message);
            }
            return value;
        }
        public static void changeConfiguration(RuntimeConfig runtimeConfig)
        {

            Console.WriteLine("Sumber pendapatan saat ini: " + runtimeConfig.config.sumberPendapatan);
            Console.Write("Masukkan sumber pendapatan baru: (gaji/dividen/saham) ");
            string newSumberPendapatan = Console.ReadLine();
            runtimeConfig.config.sumberPendapatan = newSumberPendapatan;

            Console.WriteLine("Sumber pengeluaran saat ini: " + runtimeConfig.config.sumberPengeluaran);
            Console.Write("Masukkan sumber pengeluaran baru:  (primer/sekunder/tersier) ");
            string newSumberPengeluaran = Console.ReadLine();
            runtimeConfig.config.sumberPengeluaran = newSumberPengeluaran;

            Console.WriteLine("Jangka analisis saat ini: " + runtimeConfig.config.jangkaAnalisis);
            Console.Write("Masukkan jangka analisis baru: (harian/mingguan/tahunan) ");
            string newJangkaAnalisis = Console.ReadLine();
            runtimeConfig.config.jangkaAnalisis = newJangkaAnalisis;

            runtimeConfig.WriteConfig();

            Console.WriteLine("Konfigurasi berhasil diubah!");
        }
    }


}