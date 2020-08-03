using System;
using System.Collections.Generic;

using AE.Domain;

namespace AE.WebAPI
{
    public class UserApi : IUserApi
    {
        private Dictionary<string, User> storage;

        public UserApi(Dictionary<string, User> storage)
        {
            this.storage = storage;
        }

        public User GetUser(string userName)
        {
            return storage.TryGetValue(userName, out var user) ? user : generateNewUser(userName);
        }

        private User generateNewUser(string userName)
        {
            Random rnd = new Random();
            var user = new User(userName, (System.Drawing.KnownColor)rnd.Next(Enum.GetNames(typeof(System.Drawing.KnownColor)).Length - 1));
            storage[userName] = user;
            return user;
        }
    }
}
