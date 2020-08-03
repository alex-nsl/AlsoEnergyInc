using AE.Domain;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AE.WebAPI
{
    public class UserApiFactory
    {
        public static IUserApi CreateApi(IConfiguration configuration)
        {
            return new UserApi(new Dictionary<string, User>()); // rather should be seom IStorage interface
        }
    }
}
