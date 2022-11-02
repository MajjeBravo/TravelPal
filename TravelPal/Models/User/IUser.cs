
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
