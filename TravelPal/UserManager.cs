using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Models.User;

namespace TravelPal
{
    public class UserManager
    {
        public List<IUser> users = new();
        public IUser? signedInUser { get; set; }

        public bool addUser(IUser userToAdd)
        {
            int userIndex = users.FindIndex(user => user.Username.ToLower().Equals(userToAdd.Username.ToLower()));

            if (userIndex == -1 && validateUsername(userToAdd.Username) && validatePassword(userToAdd.Password))
            {
                users.Add(userToAdd);
                return true;
            }

            return false;

        }
        public bool removeUser(IUser user)
        {

            return users.Remove(user);
        }

        public bool updateUsername(IUser userToUpdate, string newUsername)
        {
            int userIndex = users.FindIndex(user => user.Username.Equals(newUsername));

            bool userNameAlreadyExists = false;
            int userI = 0;
            foreach(IUser user in users)
            {
                if(user.Username == newUsername)
                {
                    userNameAlreadyExists = true;
                }

                userI++;
            }

            if (userIndex == -1 && validateUsername(newUsername))
            {
                users[userIndex].Username = newUsername;
                return true;
            }

            return false;
        }

        private bool validateUsername(string username)
        {
            return username.Length > 20 || username.Length < 3 ? false : true;
        }


        private bool validatePassword(string password)
        {
            return password.Length > 20 || password.Length < 5 ? false : true;
        }

        public bool signInUser(string username, string password)
        {
            int userIndex = users.FindIndex(user => user.Username.Equals(username) && user.Password.Equals(password));

            if (userIndex == -1)
            {
                return false;
            }
            else
            {
                signedInUser = users[userIndex];
                return true;
            }

        }

    }
}


