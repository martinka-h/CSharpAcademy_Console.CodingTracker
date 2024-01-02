using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class Helpers
    {
        internal static string GetDateTimeInput(string message)
        {
            string dateInput = "";
            var cultureInfo = new CultureInfo("en-US");

            do
            {
                Console.WriteLine(message);
                Console.WriteLine("(Format: yyyy-MM-dd HH:mm)");
                dateInput = Console.ReadLine();

            } while (!DateTime.TryParseExact(dateInput, "yyyy-MM-dd HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out _));

            return dateInput;
        }
    }
}
