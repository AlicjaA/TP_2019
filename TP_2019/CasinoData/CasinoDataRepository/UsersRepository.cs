﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;

namespace CasinoData
{
    public partial class CasinoDataRepository
    {
        public void AddUser(User user)
        {
            dataContext.Users.Add(user);
            dataContext.SaveChanges();
        }

        public User GetUser(int id)
        {
            return dataContext.Users.FirstOrDefault(uID => uID.ID == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return dataContext.Users;
        }

        public void UpdateUser(User oldUser, User newUser)
        {
            oldUser.FirstName = newUser.FirstName;
            oldUser.LastName = newUser.LastName;
            dataContext.SaveChanges();
        }

        public bool DeleteUser(User user)
        {
            dataContext.Users.Remove(user);
            dataContext.SaveChanges();
            return true;
        }

    }
}
