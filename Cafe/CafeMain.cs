using System;
using System.Collections.Generic;
using System.IO;
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
            List<User> users = new List<User>();
            User user = new User("", "", "", "");
            Adress ad = new Adress("", "", 0, 0, 0);
            Cafes cafe1 = new Cafes("", ad, "", "", "");
            StreamReader reader;
            StreamWriter writer;
            using (reader = new StreamReader("Users.txt"))
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    String[] words = line.Split(' ');
                    users.Add(new User(words[0], words[1], words[2], words[3]));
                }
                reader.Close();
            }
            using (reader = new StreamReader("Cafes.txt"))
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    String[] words = line.Split(' ');
                    cafeList.Add(new Cafes(words[0], new Adress(words[1], words[2], int.Parse(words[3]), double.Parse(words[4]), double.Parse(words[5])),
                        words[6], words[7], words[8]));
                }
                reader.Close();
            }

            using (reader = new StreamReader("Reviews.txt"))
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    String[] words = line.Split(' ');
                    foreach (Cafes cafe in cafeList)
                    {
                        if (cafe.name == words[0])
                        {
                            cafe.reviews.Add(new Review(words[1], words[2], words[3]));
                        }
                    }
                }
                reader.Close();
            }
        X:
            Console.WriteLine("W E L C O M E ! \nIf you want to sign up, type 'r' \nIf you want to sign in, type 's'");
            String answer = Console.ReadLine().ToLower();
            if (answer == "s")
            {
                Console.Write("Username: ");
                String username = Console.ReadLine();
                while (true)
                {
                    if (username != "")
                        break;
                    if (username == "")
                        Console.WriteLine("Please write your username!");
                    username = Console.ReadLine();
                }
                Console.Write("Password: ");
                Password.GetPass();
                Console.WriteLine("\n");
                String password = Password.pass;
                while (true)
                {
                    if (password != "")
                        break;
                    if (password == "")
                        Console.WriteLine("Please write your password!");
                    password = Console.ReadLine();
                }
                foreach (User user1 in users)
                {
                    if (user1.username == username && Encode.Decrypt(user1.password) == password)
                    {
                        user = user1;
                        goto Y;
                    }
                }
                Console.WriteLine("Wrong username or password");
                goto X;
            }
            else if (answer == "r")
            {
                Console.Write("Username: ");
            P:
                String username = Console.ReadLine();
                while (true)
                {
                    foreach (User user1 in users)
                    {
                        if (user1.username == username)
                        {
                            Console.WriteLine("Your username is not available \n Try again!");
                            goto P;
                        }
                    }
                    if (username != "")
                        break;
                    if (username == "")
                    {
                        Console.WriteLine("Please write your username!");
                        username = Console.ReadLine();
                    }
                }
                Console.Write("Password: ");
                Password.GetPass();
                String password = Password.pass;
                Console.WriteLine();
                while (true)
                {
                    if (password != "")
                        break;
                    if (password == "")
                        Console.WriteLine("Please write your password!");
                    Password.GetPass();
                    password = Password.pass;
                }
                Console.Write("Name: ");
                String name = Console.ReadLine();
                while (true)
                {
                    if (name != "")
                        break;
                    if (name == "")
                        Console.WriteLine("Please write your name!");
                    name = Console.ReadLine();
                }
                Console.Write("Surname: ");
                String surname = Console.ReadLine();
                while (true)
                {
                    if (surname != "")
                        break;
                    if (surname == "")
                        Console.WriteLine("Please write your surname!");
                    surname = Console.ReadLine();
                }
                user = new User(name, surname, username, Encode.Encrypt(password));
                users.Add(user);
                using (writer = new StreamWriter("Users.txt", true))
                {
                    writer.Write(name + " " + surname + " " + username + " " + Encode.Encrypt(password) + "\r\n");
                    writer.Close();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again! ");
                goto X;
            }
        Y:
            while (true)
            {
                Console.WriteLine("Here's our cafe list:");
                int i = 1;
                double sum = 0;
                int quan = 0;
                foreach (Cafes cafe in cafeList)
                {
                    for (int l = 0; l < cafe.reviews.Count(); l++)
                    {
                        sum += double.Parse(cafe.reviews[l].rate);
                        quan++;
                    }
                    if (sum != 0)
                        Console.WriteLine(i + ") " + cafe.name + " " + sum / quan);
                    else
                        Console.WriteLine(i + ") " + cafe.name);
                    i++;
                    sum = 0;
                    quan = 0;
                }
                i = 1;
                Console.Write("Do you want to add cafe? Answer 'yes' or 'no': ");
                answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    Console.Write("You think you are admin? Answer 'yes' or 'no': ");
                    answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        Console.Write("Oh, ok. What is the music of life?: ");
                        Password.GetPass();
                        answer = Password.pass.ToLower();
                        if (answer == "silence my brother")
                        {
                            Console.WriteLine("\nWelcome home Sargis");
                        T:
                            Console.Write("Name of cafe: ");
                            String name = Console.ReadLine();
                            Console.Write("City: ");
                            String city = Console.ReadLine();
                            Console.Write("Street: ");
                            String street = Console.ReadLine();
                            Console.Write("Number: ");
                            int num = int.Parse(Console.ReadLine());
                            Console.Write("Latitude: ");
                            double lat = double.Parse(Console.ReadLine());
                            Console.Write("Longitude: ");
                            double lon = double.Parse(Console.ReadLine());
                            Console.Write("Web-site: ");
                            String web = Console.ReadLine();
                            Console.Write("Phone number(without spacebars): ");
                            String phonenum = Console.ReadLine();
                            Console.Write("Open Times(example` 09:00-10:00): ");
                            String ot = Console.ReadLine();
                            Adress adress = new Adress(city, street, num, lat, lon);
                            Cafes cafe = new Cafes(name, adress, web, phonenum, ot);
                            cafeList.Add(cafe);
                            using (writer = new StreamWriter("Cafes.txt", true))
                            {
                                writer.Write(name + " " + city + " " + street + " " + num + " " + lat + " " + lon + " " + web +
                                    " " + phonenum + " " + ot + " " + "\r\n");
                                writer.Close();
                            }
                            Console.Write("Cafe successfully added! Another one?: ");
                            answer = Console.ReadLine().ToLower();
                            if (answer == "yes")
                                goto T;
                            else
                                goto D;
                        }
                        else
                        {
                            Console.WriteLine("You almost had it! Better luck next time :)");
                            goto D;
                        }
                    }
                    else if (answer == "no")
                    {
                        Console.WriteLine("You almost had it! Better luck next time :)");
                        goto D;
                    }
                }
                else if (answer == "no")
                {
                    Console.WriteLine("You almost had it! Better luck next time :)");
                    goto D;
                }
            D:
                Console.Write("\nChoose cafe! Enter cafes name or enter its number: ");
            C:
                String SearchedCafe = Console.ReadLine().ToLower();
                int j = 0;
                if (SearchedCafe == "q")
                    return;
                if (SearchedCafe == "c")
                    goto X;
                foreach (Cafes cafe in cafeList)
                {
                    if (SearchedCafe == cafe.name.ToLower())
                    {
                        cafe.Print();
                        Console.WriteLine("If you want to save cafe, type 'S'" + "\n" + "If you want to find nearby cafes, type 'N' \nIf you want to skip this part, press Enter");
                        answer = Console.ReadLine().ToLower();
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
                        { }
                        else
                        {
                            while (true)
                            {
                                Console.WriteLine("Rate should be a number between 1-5!");
                                rate = Console.ReadLine();
                                if (rate == "1" || rate == "2" || rate == "3" || rate == "4" || rate == "5")
                                {
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
                        Review rev = new Review(user.username, rate, comment);
                        cafe.reviews.Add(rev);
                        using (writer = new StreamWriter("Reviews.txt", true))
                        {
                            writer.Write(cafe.name + " " + user.username + " " + rate + " " + comment + "\r\n");
                            writer.Close();
                        }
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
                        Console.WriteLine("If you want to save cafe, type 'S'" + "\n" + "If you want to find nearby cafes, type 'N' \nIf you want to skip this part, press Enter");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "s")
                            user.Save(cafe);
                        if (answer == "n")
                        {
                            Console.Write("Enter the maximum distance from your cafe (in meters): ");
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
                        { }
                        else
                        {
                            while (true)
                            {
                                Console.WriteLine("Rate should be a number between 1-5!");
                                rate = Console.ReadLine();
                                if (rate == "1" || rate == "2" || rate == "3" || rate == "4" || rate == "5")
                                    break;
                                if (rate == "")
                                    break;
                            }
                        }
                        Console.Write("Add your comment: ");
                        String comment = Console.ReadLine();
                        Review rev = new Review(user.name, rate, comment);
                        cafe.reviews.Add(rev);
                        using (writer = new StreamWriter("Reviews.txt", true))
                        {
                            writer.Write(cafe.name + " " + user.username + " " + rate + " " + comment + "\r\n");
                            writer.Close();
                        }
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