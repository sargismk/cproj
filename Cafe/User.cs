using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class User
    {
        public String name { get; set; }
        public String surname { get; set; }
        public String username { get; set; }
        public String password { get; set; }

        public User(String name, String surname, String username, String password)
        {
            this.name = name;
            this.surname = surname;
            this.username = username;
            this.password = password;
        }
        List<Cafes> Favourite = new List<Cafes>();
        public void Save(Cafes cafe)
        {
            Favourite.Add(cafe);
            Console.WriteLine("Saved!");
        }
        public void PrintFavourite()
        {
            foreach (var cafe in Favourite)
            {
                Console.WriteLine(cafe.name);
            }
        }
    }
}