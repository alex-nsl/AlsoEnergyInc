using AE.Domain;

namespace AE.WebAPI
{
    public interface IUserApi
    {
        User GetUser(string userName);
    }
}
