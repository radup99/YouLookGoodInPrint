using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Entities;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("SignIn")]
    public class SignInController : ControllerBase
    {
        private readonly Database database = new Database();

        [HttpPost]
        public string Post([FromBody] Credentials credentials)
        {
            if (!database.UserExists(credentials.Username))
                return "Username does not exist.";

            if (!database.PasswordIsCorrect(credentials.Username, credentials.Password))
                return "Incorrect password.";

            return database.GetUserToken(credentials.Username);
            
        }

    }
}
