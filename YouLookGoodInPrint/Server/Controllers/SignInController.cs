using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Data;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("SignIn")]
    public class SignInController : ControllerBase
    {
        private readonly UserDataAccess Users = new UserDataAccess();

        [HttpPost]
        public ServerMessage Post([FromBody] Credentials credentials)
        {
            ServerMessage response = new ServerMessage();

            if (!Users.UsernameExists(credentials.Username))
            {
                response.Type = "error";
                response.Message = "Username does not exist.";
                return response;
            }
                

            if (!Users.IsPasswordCorrect(credentials.Username, credentials.Password))
            {
                response.Type = "error";
                response.Message = "Incorrect password.";
                return response;
            }

            response.Type = "token";
            response.Message = Users.GetUserToken(credentials.Username);
            return response;
        }

    }
}
