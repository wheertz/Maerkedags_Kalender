using System;
using System.Globalization;
using System.Linq;

namespace MærkedagsKalender
{
    class Program
    {
        static void Main(string[] args)
        {
            // Angiv måned og år
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            // Loop for at vise en måned ad gangen
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Kalender for {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}");
                Console.WriteLine("Man  Tir  Ons  Tor  Fre  Lør  Søn");

                DateTime currentDate = new DateTime(year, month, 1);
                int daysInMonth = DateTime.DaysInMonth(year, month);
                int currentDayOfWeek = (int)currentDate.DayOfWeek;

                // Flyt markøren til den første dag i ugen
                Console.CursorLeft = currentDayOfWeek * 4;

                // Definer en liste over danske helligdage
                DateTime[] danishHolidays = new DateTime[]
                {
                    new DateTime(year, 1, 1),   // Nytårsdag
                    new DateTime(year, 4, 6),   // Skærtorsdag
                    new DateTime(year, 4, 7),   // Langfredag
                    new DateTime(year, 4, 9),   // Påskedag
                    new DateTime(year, 4, 10),  // 2. påskedag
                    new DateTime(year, 5, 5),   // Store Bededag
                    new DateTime(year, 5, 18),  // Kristi Himmelfartsdag
                    new DateTime(year, 5, 28),  // Pinsedag
                    new DateTime(year, 5, 29),  // 2. pinsedag
                    new DateTime(year, 12, 24), // Juleaften
                    new DateTime(year, 12, 25), // Juledag
                    new DateTime(year, 12, 26), // 2. juledag
                    new DateTime(year, 12, 31)  // Nytårsaften
                };


                // Udskriv helligdagenavne
                Console.WriteLine($"Helligdage i {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)}:");
                foreach (var holiday in danishHolidays)
                {
                    if (holiday.Month == month)
                    {
                        Console.WriteLine($"{holiday.Day}: {GetDanishHolidayName(holiday)}");

                    }
                }

                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Kalender: ");

                for (int day = 1; day <= daysInMonth; day++)
                {
                    // Farvemærkning for helligdage
                    bool isHoliday = false;
                    foreach (var holiday in danishHolidays)
                    {
                        if (holiday.Month == month && holiday.Day == day)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            isHoliday = true;
                            break;
                        }
                    }

                    // Farvemærkning for den aktuelle dag
                    if (day == DateTime.Now.Day && month == DateTime.Now.Month && year == DateTime.Now.Year)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    Console.Write($"{day,3}");

                    // Nulstil farver
                    Console.ResetColor();

                    // Hvis det er søndag, gå til næste linje
                    if (currentDayOfWeek == 6)
                    {
                        Console.WriteLine();
                        currentDayOfWeek = 0;
                    }
                    else
                    {
                        currentDayOfWeek++;
                    }
                }

                Console.WriteLine("\nTryk på en tast for at fortsætte til næste måned...");
                Console.ReadKey();

                // Skift til næste måned
                if (month == 12)
                {
                    month = 1;
                    year++;
                }
                else
                {
                    month++;
                }
            }
        }

        // Hjælpefunktion til at få helligdagsnavn
        static string GetDanishHolidayName(DateTime holiday)
        {
            switch (holiday.Day)
            {
                case 1:
                    return "Nytårsdag";
                case 6:
                    return "Skærtorsdag";
                case 7:
                    return "Langfredag";
                case 9:
                    return "Påskedag";
                case 10:
                    return "2. påskedag";
                case 5:
                    return "Store Bededag";
                case 18:
                    return "Kristi Himmelfartsdag";
                case 28:
                    return "Pinsedag";
                case 29:
                    return "2. pinsedag";
                case 24:
                    return "Juleaften";
                case 25:
                    return "Juledag";
                case 26:
                    return "2. juledag";
                case 31:
                    return "Nytårsaften";
                default:
                    return "Ukendt helligdag";
            }
        }
    }
}
