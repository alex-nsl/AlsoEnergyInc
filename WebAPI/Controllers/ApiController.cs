using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AE.Domain;
using AE.WebAPI;
using AE.CoreUtility;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> logger;
        private readonly IUserApi userApi;

        public ApiController(ILogger<ApiController> logger, IUserApi userApi)
        {
            this.logger = logger;
            this.userApi = userApi; 
        }

        [HttpGet("User/{id}", Name = nameof(GetUser))]
        public User GetUser(string id)
        {
            return userApi.GetUser(id);
        }
   }
}
