using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TravelPal
{
    public interface IUser
    {
         string Username { get; set; }

         string Password { get; set; }

         Country Location { get; set; }
    }


}
