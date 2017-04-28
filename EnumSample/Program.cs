using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumSample
{
    class Program
    {
        static void Main(string[] args)
        {
            DaysOfWeek day1 = DaysOfWeek.Friday;
            DaysOfWeek day2 = DaysOfWeek.Saturday;
            Console.WriteLine(day1 + " " + (int)day1);
            Print(day1);
            int a = 1;
            Console.WriteLine((DaysOfWeek)a);
            Print(DaysOfWeek.Monday);
            PrintAllEnumValues();
        }
        static void Print(DaysOfWeek day)
        {
            switch (day)
            {
                case DaysOfWeek.Friday:
                    Console.WriteLine("It's Friday mate");
                    break;
                default:
                    Console.WriteLine("I'm sorry, but it's not Friday");
                    break;
            }
        }
        static void PrintAllEnumValues()
        {
            string[] enumNames = Enum.GetNames(typeof(DaysOfWeek));
            for (int i = 0; i < enumNames.Length; i++)
            {
                DaysOfWeek day = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), enumNames[i]);
                Console.WriteLine(day + " " + (int)day);
            }
        }
    }
}
