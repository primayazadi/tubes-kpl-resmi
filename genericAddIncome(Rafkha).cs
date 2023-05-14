using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tubesbackuup
{
    public class genericAddIncome_Rafkha_
    {
        static void AddIncome<T>(User user)
        where T : struct, IComparable, IConvertible, IFormattable
        {
            T amount = GetInputFromUser<T>("Amount: ");
            user.TotalIncome += Convert.ToDecimal(amount);
            Console.WriteLine($"${amount} has been added to your income.");
        }

        static T GetInputFromUser<T>(string message)
                where T : struct, IComparable, IConvertible, IFormattable
        {
            Console.Write(message);
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    T result = (T)Convert.ChangeType(input, typeof(T));
                    return result;
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.Write(message);
                }
            }
        }
    }
}
