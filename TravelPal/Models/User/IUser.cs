using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelPal.Models.Enums;

namespace TravelPal.Models.User
{
    public interface IUser
    {
        string Username { get; set; }

        string Password { get; set; }

        Country Location { get; set; }
    }


}
