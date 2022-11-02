using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Models.Enums;

namespace TravelPal.Models.User
{
    public class Admin : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }

        public Admin(string username, string password, Country location)
        {
            Username = username;
            Password = password;
            Location = location;
        }
    }
}
