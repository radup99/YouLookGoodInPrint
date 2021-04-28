using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Data;
using YouLookGoodInPrint.Server.Entities;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("SignIn")]
    public class SignInController : ControllerBase
    {
        private readonly UserDataAccess Users;
        private TokenList Tokens;

        public SignInController(Database database, TokenList tokenList)
        {
            Database _database = database;
            Users = new UserDataAccess(_database);
            Tokens = tokenList;
        }

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
            response.Message = Tokens.GetToken(credentials.Username);
            return response;
        }

    }
}
