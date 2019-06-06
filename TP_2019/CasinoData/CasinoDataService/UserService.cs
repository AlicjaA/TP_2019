using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoData;
using CasinoDataModelLibrary;

namespace CasinoData
{
    public partial class CasinoDataService
    {
        public string PrintUsers(List<User> users)
        {
            string usersString = "";

            foreach (User user in users)
            {
                usersString += user;
                if (users.LastIndexOf(user) != users.Count)
                {
                    usersString += ", ";
                }
            }

            return usersString;
        }

        public void AddUser(User user)
        {
            if (!casinoDataRepository.GetAllUsers().Contains(user))
            {
                casinoDataRepository.AddUser(user);
            }
            else
            {
                throw new Exception("User alredy exists!");
            }
        }

        public void DeleteUser(User user)
        {
            if (casinoDataRepository.GetAllUsers().Contains(user))
            {
                casinoDataRepository.DeleteUser(user);
            }
            else
            {
                throw new Exception("User not found!");
            }
        }

        public void UpdateUser(User oldUser, User newUser)
        {
            if (casinoDataRepository.GetAllUsers().Contains(oldUser))
            {
                casinoDataRepository.UpdateUser(oldUser, newUser);
            }
            else
            {
                throw new Exception("Error. Can't update and change user!");
            }
        }

    }
}