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
            Console.Write("Enter your name and surname: ");
            String line = Console.ReadLine();
            if (line == "q")
                return;
            String[] arr = line.Split(' ');
            String name = arr[0];
            String surname = arr[1];
            User user = new User(name, surname);
            List<Cafes> cafeList = new List<Cafes>();
            Adress adress1 = new Adress("Erevan", "Saryan", 24);
            Cafes cafe1 = new Cafes("Cafe Lounge", adress1, "http://www.lounge.com", "+374 10 20 34 44", "10:00 - 22:00", 0.0, 1);
            cafeList.Add(cafe1);
            Adress adress2 = new Adress("Erevan", "Tumayan", 13);
            Cafes cafe2 = new Cafes("Jazzve", adress2, "http://www.jazzve.com", "+374 10 53 35 35", "09:00 - 23:00", 0.0, 1);
            cafeList.Add(cafe2);
            Adress adress3 = new Adress("Erevan", "Mashtots av.", 44);
            Cafes cafe3 = new Cafes("Green Bean", adress3, "http://www.gbcafearmenia.com", "+374 10 55 44 78", "07:00 - 00:00", 0.0, 1);
            cafeList.Add(cafe3);
            while (true)
            {
                Console.WriteLine("Here's our cafe list");
                foreach (var cafe in cafeList)
                {
                    if (cafe.rate != 0)
                        Console.WriteLine(cafe.name + " " + cafe.rate);
                    else
                        Console.WriteLine(cafe.name);
                }
                Console.Write("Choose cafe, enter cafes name: ");
                String SearchedCafe = Console.ReadLine().ToLower();
                if (SearchedCafe == "q")
                    return;
                foreach (Cafes cafe in cafeList)
                {
                    if (SearchedCafe == cafe.name.ToLower())
                    {
                        cafe.Print();
                        Console.WriteLine("If you want to save cafe, type 'S'" + "\n" + "If you want to find nearby cafes, type 'N' \nIf you want to skip this part, press Enter");
                        String answer = Console.ReadLine().ToLower();
                        if (answer == "s")
                            user.Save(cafe);
                        if (answer == "n")
                        {

                        }
                        if (answer == "q")
                        {
                            return;
                        }
                        Console.Write("Rate from 1 to 5: ");
                        String rate = Console.ReadLine();
                        if (rate == "q")
                        {
                            return;
                        }
                        if (rate == "1" || rate == "2" || rate == "3" || rate == "4" || rate == "5")
                        {
                            
                            cafe.rate += int.Parse(rate);
                            cafe.rate /= cafe.rates;
                            cafe.rates++;
                        }
                        else
                        {
                            while (true)
                            {
                                Console.WriteLine("Rate should be a number between 1-5!");
                                rate = Console.ReadLine();
                                if (rate == "1" || rate == "2" || rate == "3" || rate == "4" || rate == "5")
                                {
                                    cafe.rate += int.Parse(rate);
                                    cafe.rate /= cafe.rates;
                                    cafe.rates++;
                                    break;
                                }
                            }
                        }
                        Console.Write("Add your comment: ");
                        String comment = Console.ReadLine();
                        Review rev = new Review(user, cafe, rate, comment);
                        rev.AddReview(rev);

                        Console.WriteLine("Thank you! \nIf you want to quit, type 'Q'! \nIf you want to continue searching cafes, press Enter!");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "q")
                        {
                            return;
                        }
                    }
                }
            }
        }
    }
}