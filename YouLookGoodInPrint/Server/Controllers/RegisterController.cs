using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Entities;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("Register")]
    public class RegisterController : ControllerBase
    {
        private readonly UserDataAccess Users = new UserDataAccess();

        [HttpPost]
        public string Post([FromBody] RegistrationData rdata)
        {
            if (Users.UserExists(rdata.Username))
                return "Username already exists.";

            Users.AddUser(rdata.Username, rdata.Password, rdata.RealName, rdata.Email);
            return "Registration complete!";
        }
    }
}
