using System.Collections.Generic;
using TravelPal.Models.Enums;

namespace TravelPal.Models.User
{
    internal class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }

        public List<Travels.Travel> Travels = new(); 



        public User(string username, string password, Country location)
        {
            Username = username;
            Password = password;
            Location = location;
        }

    }
}
