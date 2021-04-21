using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Data;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("Print")]
    public class PrintController : ControllerBase
    {
        private readonly UserDataAccess Users;
        private readonly PrintDataAccess Prints;

        public PrintController(Database database)
        {
            Database _database = database;
            Users = new UserDataAccess(_database);
            Prints = new PrintDataAccess(_database);
        }

        [HttpPost]
        public ServerMessage Post([FromBody] EntityData<Print> printData)
        {
            ServerMessage response = new ServerMessage();

            if (!Users.isTokenValid(printData.Username, printData.Token))
            {
                response.Type = "error";
                response.Message = "Invalid token!";
                return response;
            }

            response.Type = "success";
            response.Message = "Print request received successfully!";
            Prints.Add(printData.Item);
            return response;
        }

    }
}
