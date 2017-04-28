using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class CafeMain
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            String line = Console.ReadLine();
            String[] arr = line.Split(' ');
            String name = arr[0];
            String surname = arr[1];
            User user = new User(name, surname);
            List<Cafes> cafeList = new List<Cafes>();
            Adress adress1 = new Adress("Erevan", "Saryan", 24);
            Cafes cafe1 = new Cafes("Cafe Lounge", adress1, "http://www.lounge.com", "+374 10 20 34 44", "10:00 - 22:00");
            cafeList.Add(cafe1);
            Adress adress2 = new Adress("Erevan", "Tumayan", 13);
            Cafes cafe2 = new Cafes("Jazzve", adress2, "http://www.jazzve.com", "+374 10 53 35 35", "09:00 - 23:00");
            cafeList.Add(cafe2);
            Console.Write("Enter cafes name: ");
            String SearchedCafe = Console.ReadLine();
            foreach (Cafes cafe in cafeList)
            {
                if(SearchedCafe == cafe.name)
                {
                    cafe.Print();
                    Console.WriteLine("If you want to save cafe, type 'S'" + "\n" + "If you want to find nearby cafes, type 'N'");
                    String answer = Console.ReadLine().ToLower();
                    if (answer == "s")
                        user.Save(cafe);
                    if (answer == "n")
                    {

                    }
                    Console.WriteLine("Do you want to rate this cafe?");
                    String answer1 = Console.ReadLine().ToLower();
                    if (answer1 == "yes")
                    {
                        Console.WriteLine("Rate from 1 to 5");
                        int rate = int.Parse(Console.ReadLine());

                    }
                }
            }
        }
    }
}
