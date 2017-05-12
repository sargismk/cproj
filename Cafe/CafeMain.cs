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
            List<Cafes> cafeList = new List<Cafes>();
            List<Review> reviews = new List<Review>();
            List<User> users = new List<User>();
            Adress adress1 = new Adress("Erevan", "Moskovyan", 3, 40.184152, 44.522341);
            Cafes cafe1 = new Cafes("LOFT", adress1, "http://www.loft.am", "+374 10 20 34 44", "10:00 - 22:00", 0.0, 1);
            cafeList.Add(cafe1);
            Adress adress2 = new Adress("Erevan", "Tumayan", 35, 40.186701, 44.511039);
            Cafes cafe2 = new Cafes("Jazzve", adress2, "http://www.jazzve.com", "+374 10 53 35 35", "09:00 - 23:00", 0.0, 1);
            cafeList.Add(cafe2);
            Adress adress3 = new Adress("Erevan", "Amiryan", 4, 40.179177, 44.51061);
            Cafes cafe3 = new Cafes("Green Bean", adress3, "http://www.gbcafearmenia.com", "+374 10 55 44 78", "07:00 - 00:00", 0.0, 1);
            cafeList.Add(cafe3);
            Adress adress4 = new Adress("Erevan", "Grigor Lusavorich str.", 31, 40.17384, 44.50569);
            Cafes cafe4 = new Cafes("El Sky", adress4, "http://www.elskybar.am", "+374 91 414816", "10:00 - 03:00", 0.0, 1);
            cafeList.Add(cafe4);
        X:
            Console.Write("Enter your name: ");
            String name = Console.ReadLine();
            while (true)
            {
                if (name != "")
                    break;
                if (name == "")
                    Console.WriteLine("Please write your name!");
                name = Console.ReadLine();
            }
            Console.Write("Enter your surname: ");
            String surname = Console.ReadLine();
            while (true)
            {
                if (surname != "")
                    break;
                if (surname == "")
                    Console.WriteLine("Please write your surname!");
                surname = Console.ReadLine();
            }
            User user = new User(name, surname);
        Y:
            while (true)
            {
                Console.WriteLine("Here's our cafe list:");
                int i = 1;
                foreach (var cafe in cafeList)
                {
                    if (cafe.rate != 0)
                        Console.WriteLine(i + ") " + cafe.name + " " + cafe.rate);
                    else
                        Console.WriteLine(i + ") " + cafe.name);
                    i++;
                }
                i = 1;
                Console.Write("\nChoose cafe! Enter cafes name or enter its number: ");
                C:
                String SearchedCafe = Console.ReadLine().ToLower();
                int j = 0;
                if (SearchedCafe == "q")
                    return;
                foreach (Cafes cafe in cafeList)
                {
                    if (SearchedCafe == cafe.name.ToLower())
                    {
                        cafe.Print();
                        Console.WriteLine("Reviews about " + cafe.name + ": \n");
                        foreach (Review review in reviews)
                        {
                            if (cafe.name == review.cafe.name)
                            {
                                review.RevPrint();
                            }
                        }
                        Console.WriteLine("If you want to save cafe, type 'S'" + "\n" + "If you want to find nearby cafes, type 'N' \nIf you want to skip this part, press Enter");
                        Console.WriteLine("If you want to see your saved cafes, type 'P'");
                        String answer = Console.ReadLine().ToLower();
                        if (answer == "s")
                            user.Save(cafe);
                        
                        if (answer == "n")
                        {
                            Console.WriteLine("Enter the maximum distance from your cafe (in meters): ");
                            long distance = long.Parse(Console.ReadLine());
                            foreach (Cafes cafes in cafeList)
                            {
                                if (cafe.name != cafes.name && cafe.adress.coord.GetDistanceTo(cafes.adress.coord) < distance)
                                {
                                    Console.WriteLine("" + i + ") " + cafes.name);
                                    i++;
                                }
                            }
                            if (i == 1)
                            {
                                Console.WriteLine("No cafes found nearby!");
                                goto B;
                            }
                            i = 1;
                            Console.Write("Choose a cafe, enter its name: ");
                            goto C;
                        }
                        if (answer == "p")
                            user.PrintFavourite();
                        if (answer == "q")
                            return;
                        Console.Write("Rate from 1 to 5: ");
                        String rate = Console.ReadLine();
                        if (rate == "q")
                        {
                            return;
                        }
                        if (rate == "")
                        {
                            goto B;
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
                                if (rate == "")
                                {
                                    break;
                                }
                            }
                        }
                        Console.Write("Add your comment: ");
                        String comment = Console.ReadLine();
                        Review rev = new Review(user, cafe, rate, comment);
                        reviews.Add(rev);
                    B:
                        Console.WriteLine("\nThank you! \nIf you want to quit, type 'Q'! \nIf you want to continue searching cafes, press Enter!");
                        Console.WriteLine("If you want to login as another user, type 'C'!");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "q")
                            return;
                        if (answer == "c")
                            goto X;
                        if (answer == "")
                            goto Y;
                    }
                }
                foreach (Cafes cafe in cafeList)
                {
                    if (int.Parse(SearchedCafe) == j + 1)
                    {
                        cafe.Print();
                        Console.WriteLine("Reviews about " + cafe.name + ": \n");
                        foreach (Review review in reviews)
                        {
                            if (cafe.name == review.cafe.name)
                            {
                                review.RevPrint();
                            }
                        }
                        Console.WriteLine("If you want to save cafe, type 'S'" + "\n" + "If you want to find nearby cafes, type 'N' \nIf you want to skip this part, press Enter");
                        Console.WriteLine("If you want to see your saved cafes, type 'P'");
                        String answer = Console.ReadLine().ToLower();
                        if (answer == "s")
                            user.Save(cafe);
                        if (answer == "n")
                        {
                            Console.WriteLine("Enter the maximum distance from your cafe (in meters): ");
                            long distance = long.Parse(Console.ReadLine());
                            foreach (Cafes cafes in cafeList)
                            {
                                if (cafe.name != cafes.name && cafe.adress.coord.GetDistanceTo(cafes.adress.coord) < distance)
                                {
                                    Console.WriteLine("" + i + ") " + cafes.name);
                                    i++;
                                }
                            }
                            if (i == 1)
                            {
                                Console.WriteLine("No cafes found nearby!");
                                goto B;
                            }
                            i = 1;
                            Console.Write("Choose a cafe, enter its name: ");
                            goto C;
                        }
                        if (answer == "p")
                            user.PrintFavourite();
                        if (answer == "q")
                            return;
                        Console.Write("Rate from 1 to 5: ");
                        String rate = Console.ReadLine();
                        if (rate == "q")
                        {
                            return;
                        }
                        if (rate == "")
                        {
                            goto B;
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
                                if (rate == "")
                                {
                                    break;
                                }
                            }
                        }
                        Console.Write("Add your comment: ");
                        String comment = Console.ReadLine();
                        Review rev = new Review(user, cafe, rate, comment);
                        reviews.Add(rev);
                    B:
                        Console.WriteLine("\nThank you! \nIf you want to quit, type 'Q'! \nIf you want to continue searching cafes, press Enter!");
                        Console.WriteLine("If you want to login as another user, type 'C'!");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "q")
                        {
                            return;
                        }
                        if (answer == "c")
                        {
                            goto X;
                        }
                    }
                    j++;
                }
            }
        }
    }
}