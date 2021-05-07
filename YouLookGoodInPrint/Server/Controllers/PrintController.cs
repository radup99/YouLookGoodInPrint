using Microsoft.AspNetCore.Mvc;
using YouLookGoodInPrint.Shared;
using YouLookGoodInPrint.Server.Data;
using YouLookGoodInPrint.Server.Entities;

namespace YouLookGoodInPrint.Server.Controllers
{
    [ApiController]
    [Route("Print")]
    public class PrintController : ControllerBase
    {
        private readonly PrintDataAccess Prints;
        private readonly TokenList Tokens;

        public PrintController(Database database, TokenList tokenList)
        {
            Database _database = database;
            Prints = new PrintDataAccess(_database);
            Tokens = tokenList;
        }

        [HttpPost]
        public ServerMessage Post([FromBody] ItemData<Print> printData)
        {
            ServerMessage response = new ServerMessage();

            if (!Tokens.IsTokenValid(printData.Username, printData.Token))
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
