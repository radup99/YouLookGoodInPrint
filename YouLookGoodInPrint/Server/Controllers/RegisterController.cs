using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Entities;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("Register")]
    public class RegisterController : ControllerBase
    {
        private Database database = new Database();

        [HttpPost]
        public string Post([FromBody] RegistrationData rdata)
        {
            if (database.UserExists(rdata.Username))
                return "Username already exists.";

            database.AddUser(rdata.Username, rdata.Password, rdata.RealName, rdata.Email);
            return "Registration complete!";
        }
    }
}
