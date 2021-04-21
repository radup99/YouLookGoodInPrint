using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Data;
using YouLookGoodInPrint.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("Register")]
    public class RegisterController : ControllerBase
    {
        private readonly UserDataAccess Users;

        public RegisterController(Database database)
        {
            Database _database = database;
            Users = new UserDataAccess(_database);
        }

        [HttpPost]
        public string Post([FromBody] RegistrationData rdata)
        {
            if (Users.UsernameExists(rdata.Username))
                return "Username already exists.";

            User user = new User(rdata.Username, rdata.Password, rdata.RealName, rdata.Email);
            Users.Add(user);
            return "Registration complete!";
        }
    }
}
