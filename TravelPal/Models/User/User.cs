using System.Collections.Generic;
using TravelPal.Models.Enums;
using TravelPal.Models.Travels;

namespace TravelPal.Models.User
{
    public class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }

        public List<Travel> Travels = new(); 



        public User(string username, string password, Country location)
        {
            Username = username;
            Password = password;
            Location = location;
        }

        public void addTravel(Travel travelToAdd)
        {
            Travels.Add(travelToAdd);
        }

        public void removeTravel(Travel travelToRemove)
        {
            Travels.Remove(travelToRemove);
        }

    }
}
