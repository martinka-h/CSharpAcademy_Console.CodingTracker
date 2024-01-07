using System.Globalization;

namespace CodingTracker
{
    internal class Helpers
    {
        internal static string GetDateTimeInput(string message)
        {
            Console.WriteLine(message);
            string dateInput = "";
            var cultureInfo = new CultureInfo("en-US");

            do
            {
                Console.WriteLine("(Format: yyyy-MM-dd HH:mm)");
                dateInput = Console.ReadLine();

            } while (!DateTime.TryParseExact(dateInput, "yyyy-MM-dd HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out _));

            return dateInput;
        }

        public static string CalculateDuration(string endDateTime, string startDateTime)
        {
            return DateTime.Parse(endDateTime).Subtract(DateTime.Parse(startDateTime)).ToString(@"hh\:mm");
        }

        internal static string GetNumperInput(string message)
        {
            Console.WriteLine(message);
            string numberInput = Console.ReadLine();

            while (!int.TryParse(numberInput, out _))
            {
                Console.Write("Please provide a valid input.\n");
                numberInput = Console.ReadLine();
            }

            return numberInput;
        }
    }
}
