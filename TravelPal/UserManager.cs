using System.Collections.Generic;
using System.Diagnostics.Metrics;
using TravelPal.Models.Enums;
using TravelPal.Models.Travels;
using TravelPal.Models.User;

namespace TravelPal
{
    public class UserManager
    {
        public List<IUser> users = new();
        public IUser? signedInUser { get; set; }

        // Add new user 
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

        // Remove user 
        public bool removeUser(IUser user)
        {

            return users.Remove(user);
        }

        // Validate userinputs to meet criteria for name and password
        public bool[] ValidateUserInput(IUser user, string username, string password)
        {
            bool[] validInputs = { false, false };

            if(validateUsername(username))
            {
                validInputs[0] = true;
            }

            if (validatePassword(password))
            {
                validInputs[1] = true;
            }

            return validInputs;
        }

        // Remove travel 
        public void removeTravel(User userToUpdate, Travel travel)
        {
            int userIndex = users.FindIndex(user => user.Username.Equals(userToUpdate.Username));
            User signedInUser = (User)this.signedInUser;
            User userToRemove = (User)users[userIndex];
            userToRemove.removeTravel(travel);
            signedInUser.removeTravel(travel);
            //users.Remove(signedInUser);
            //users.Add(signedInUser);
            //users[userIndex] = userToRemove;
            //this.signedInUser = signedInUser;
        }

        // Add new travel
        public void addTravel(User userToUpdate, Travel travel)
        {
            int userIndex = users.FindIndex(user => user.Username.Equals(userToUpdate.Username));
            User signedInUser = (User)this.signedInUser;
            User userToAdd = (User)users[userIndex];
            userToAdd.addTravel(travel);
            users.RemoveAt(userIndex);
            users.Add(userToAdd);
            this.signedInUser = userToAdd;

          
        }

        // Update Country
        public void updateCountry(IUser userToUpdate, Country country)
        {
            int userIndex = users.FindIndex(user => user.Username.Equals(userToUpdate.Username));
            users[userIndex].Location = country;
            signedInUser.Location = country;
        }

        // Update password
        public void updatePassword(IUser userToUpdate, string newPassword)
        {
            int userIndex = users.FindIndex(user => user.Username.Equals(userToUpdate.Username));

            users[userIndex].Password = newPassword;
            signedInUser.Password = newPassword;
        }
     
        // Update username
        public void updateUsername(IUser userToUpdate, string newUsername)
        {
            int userIndex = users.FindIndex(user => user.Username.Equals(userToUpdate.Username));

            users[userIndex].Username = newUsername;
            signedInUser.Username = newUsername;
        }

        // Validate username to meet critera max 20, minimum 3
        private bool validateUsername(string username)
        {
            int userIndex = users.FindIndex(user => user.Username.Equals(username));

            if(userIndex != -1 || username.Length <= 3 || username.Length >= 20)
            { 
                return false;
            }

            return true;
        }

        // Validate password to meet criteria max 20, minimum 5
        private bool validatePassword(string password)
        {
            return password.Length >= 5 && password.Length <= 20;
        }

        // Sign in user and check through index if user + password exist and match
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


