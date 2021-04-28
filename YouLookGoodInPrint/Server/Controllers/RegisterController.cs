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
        private TokenList Tokens;

        public RegisterController(Database database, TokenList tokenList)
        {
            Database _database = database;
            Users = new UserDataAccess(_database);
            Tokens = tokenList;
        }

        [HttpPost]
        public string Post([FromBody] RegistrationData rdata)
        {
            if (Users.UsernameExists(rdata.Username))
                return "Username already exists.";

            User user = new User(rdata.Username, rdata.Password, rdata.RealName, rdata.Email);
            Users.Add(user);
            Tokens.AddUser(rdata.Username);
            return "Registration complete!";
        }
    }
}
