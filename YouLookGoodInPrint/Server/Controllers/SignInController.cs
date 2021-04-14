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
        public SignInResponse Post([FromBody] Credentials credentials)
        {
            SignInResponse response = new SignInResponse();

            if (!database.UserExists(credentials.Username))
            {
                response.Type = "error";
                response.Message = "Username does not exist.";
                return response;
            }
                

            if (!database.PasswordIsCorrect(credentials.Username, credentials.Password))
            {
                response.Type = "error";
                response.Message = "Incorrect password.";
                return response;
            }

            response.Type = "token";
            response.Message = database.GetUserToken(credentials.Username);
            return response;
        }

    }
}
